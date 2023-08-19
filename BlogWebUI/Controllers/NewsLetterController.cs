using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogWebUI.Controllers
{
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{
		private readonly INewsLetterService _newsletterService;

		public NewsLetterController(INewsLetterService newsletterService)
		{
			_newsletterService = newsletterService;
		}

		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult SubsMail(NewsLetter p)
		{
			p.Status = true;
			_newsletterService.Insert(p);
			var values = JsonConvert.SerializeObject(_newsletterService);
			return Json(values);

		}
	}
}
