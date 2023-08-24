using BlogWebUI.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Writer.Controllers
{

    [Area("Writer")]
    [Route("Writer/Profile")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserProfileEdit model = new UserProfileEdit();
            model.Name = values.Name;
            model.ImageUrl = values.ImageURL;
            return View(model);
        }
        [HttpPost]
        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index(UserProfileEdit u)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (u.Picture != null)
            {
                //yolu aldık
                var resoure = Directory.GetCurrentDirectory();
                //uzantıyı aldık
                var extension = Path.GetExtension(u.Picture.FileName);
                //resim ismi guid benzersiz bir resim ismi tanımlamak için kullandıgım bir method
                var imagename = Guid.NewGuid() + extension;
                //resmin kaydedileceği yer
                var savelocation = resoure + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await u.Picture.CopyToAsync(stream);
                user.ImageURL = "/userimage/"+ imagename;
            }
            user.Name = u.Name;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, u.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

    }
}
