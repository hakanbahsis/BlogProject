using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
   [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            var values=_aboutService.GetListAll();
            return View(values);
        }

        [Route("")]
        [Route("AddAbout")]
        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [Route("")]
        [Route("AddAbout")]
        [HttpPost]
        public IActionResult AddAbout(About about,IFormFile image1,IFormFile image2)
        {
            _aboutService.Insert(about);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("EditAbout")]
        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var values = _aboutService.GetById(id);
            return View(values);
        }


        [Route("")]
        [Route("EditAbout")]
        [HttpPost]
        public IActionResult EditAbout(About a)
        {
            _aboutService.Update(a);
            return RedirectToAction("Index");
        }
    }
}
