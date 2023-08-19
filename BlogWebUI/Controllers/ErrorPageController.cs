using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
	[AllowAnonymous]
	public class ErrorPageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Page404()
		{
			return View();
		}
	}
}
