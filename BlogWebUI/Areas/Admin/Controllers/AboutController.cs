using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
  // [Authorize(Roles = "Admin")]
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
        public IActionResult AddAbout(About about)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(about.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/images/" + imageName;
            using (var stream = new FileStream(saveLocation, FileMode.Create))
            {
                about.Image.CopyTo(stream);
            }

            about.AboutImage1 = "/images/" + imageName;
            about.AboutImage2 = "/images/" + imageName;
            about.AboutStatus = true;
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
        public IActionResult EditAbout(About a,IFormFile Image1)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(Image1.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/images/" + imageName;
            using (var stream = new FileStream(saveLocation, FileMode.Create))
            {
                Image1.CopyTo(stream);
            }

            a.AboutImage1 = "/images/" + imageName;
            a.AboutImage2 = "/images/" + imageName;
            _aboutService.Update(a);
            return RedirectToAction("Index");
        }
    }
}
