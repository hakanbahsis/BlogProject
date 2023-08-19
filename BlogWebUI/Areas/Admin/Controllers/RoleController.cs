using BlogWebUI.Areas.Admin.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Role")]

    public class RoleController : Controller
    {
        readonly RoleManager<WriterRole> _roleManager;
        readonly UserManager<WriterUser> _userManager;
        private readonly IWriterUserService _writerUserService;
        public RoleController(RoleManager<WriterRole> roleManager, UserManager<WriterUser> userManager, IWriterUserService writerUserService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _writerUserService = writerUserService;
        }

        //Rollerin Listelendiği yer
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        //Rolü Getirmek için
        [Route("")]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(string id)
        {
            if (id != null)
            {
                WriterRole role = await _roleManager.FindByIdAsync(id);
                return View(new RoleViewModel
                {
                    Name = role.Name
                });
            }
            return View();
        }

        [HttpPost]
        [Route("")]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(RoleViewModel model, string id)
        {
            IdentityResult result = null;
            if (id != null)
            {

                WriterRole role = await _roleManager.FindByIdAsync(id);
                role.Name = model.Name;
                result = await _roleManager.UpdateAsync(role);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("")]
        [Route("CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            IdentityResult result = null;
            result = await _roleManager.CreateAsync(new WriterRole { Name = model.Name });
            return RedirectToAction("UsersList", "UserList", new { area = "Admin" });
        }
        //Rol Silme
        [Route("")]
        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            WriterRole role = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(role);
            return RedirectToAction("UsersList", "UserList", new { area = "Admin" });
        }
        [HttpGet]
        [Route("")]
        [Route("RoleAssign/{id}")]
        public async Task<IActionResult> RoleAssign(string id)
        {
            //kullanıcının id sini buluyoruz
            WriterUser user = await _userManager.FindByIdAsync(id);
            //Rolleri listeliyoruz
            List<WriterRole> allRoles = _roleManager.Roles.ToList();
            //Hangi kullanıcının hangi rolü oldugunu buluyoruz
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            //Kullanıcının rolünü listeliyoruz
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));
            return View(assignRoles);
        }
        //CheckBoxtan Seçtiğin Rolü  kullanıcıya Atama eğer seçili değilse silme
        [HttpPost]
        [Route("")]
        [Route("RoleAssign/{id}")]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            WriterUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.HasAssign)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }
            //     return RedirectToAction("UserLists", "UserList", new { Areas = "Admin" });
            return RedirectToAction("UsersList", "UserList", new { area = "Admin" });
        }
    }
}
