using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/UserList")]
    public class UserListController : Controller
    {
        readonly RoleManager<WriterRole> _roleManager;
        readonly UserManager<WriterUser> _userManager;

        private readonly IWriterUserService _userService;

        public UserListController(RoleManager<WriterRole> roleManager, UserManager<WriterUser> userManager, IWriterUserService userService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userService = userService;
        }

        [Route("")]
        [Route("UsersList")]
        public IActionResult UsersList(string search)
        {
            Context c = new Context();
            var values = from s in c.Users select s;
            if (!string.IsNullOrEmpty(search))
            {
                values = values.Where(a => a.Name.Contains(search));
            }
            // var values = wm.GetList();
            return View(values.ToList());
        }

        [Route("")]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var values = _userService.GetById(id);
            _userService.Delete(values);
            return RedirectToAction("UsersList");
        }

    }
}
