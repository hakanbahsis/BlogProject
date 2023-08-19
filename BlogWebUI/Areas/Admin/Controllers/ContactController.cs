using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactBoxService _contactBoxService;

        public ContactController(IContactBoxService contactBoxService)
        {
            _contactBoxService = contactBoxService;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactBoxService.GetListAll();
            var count = _contactBoxService.GetListAll().Count();
            ViewBag.Count = count;
            return View(values);
        }

        [Route("")]
        [Route("ContactAdd")]
        [HttpGet]
        public IActionResult ContactAdd()
        {
          return View();
        }
        [Route("")]
        [Route("ContactAdd")]
        [HttpPost]
        public IActionResult ContactAdd(ContactBox c)
        {
            _contactBoxService.Insert(c);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("ContactEdit")]
        [HttpGet]
        public IActionResult ContactEdit(int id)
        {
            var values = _contactBoxService.GetById(id);
            return View(values);
        }
        [Route("")]
        [Route("ContactEdit")]
        [HttpPost]
        public IActionResult ContactEdit(ContactBox c)
        {
            _contactBoxService.Update(c);
            return RedirectToAction("Index");
        }
    }
}
