using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogWebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IContactBoxService _contactBoxService;
        public ContactController(IContactService contactService, IContactBoxService contactBoxService)
        {
            _contactService = contactService;
            _contactBoxService = contactBoxService;
        }

        public IActionResult Index()
        {
            return View();
        }

		public PartialViewResult ContactMaps()
		{
			var values = _contactBoxService.GetListAll();
			return PartialView(values);
		}


		public IActionResult ContactAdd(Contact c)
		{

			c.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			c.ContactStatus = true;
			_contactService.Insert(c);
			var values = JsonConvert.SerializeObject(c);

			return Json(values);
		}
	}
}
