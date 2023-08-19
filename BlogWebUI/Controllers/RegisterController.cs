using BlogWebUI.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly UserManager<WriterUser> _userManager;

		public RegisterController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserRegisterModel m)
		{
			if (ModelState.IsValid)
			{
				WriterUser w = new WriterUser()
				{
					Name = m.Name,
					Email = m.Email,
					UserName = m.UserName,
					ImageURL = "/userimage/resimyok.jpg"
				};
				if (m.Password == m.ConfirmPassword)
				{
					var result = await _userManager.CreateAsync(w, m.Password);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Login");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError("", item.Description);
						}
					}
				}

			}
			return View(m);
		}
	}
}
