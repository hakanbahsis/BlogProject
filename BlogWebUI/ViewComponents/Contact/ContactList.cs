using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.ViewComponents.Contact
{
    public class ContactList : ViewComponent
    {
        private readonly IContactBoxService _contactBoxService;

        public ContactList(IContactBoxService contactBoxService)
        {
            _contactBoxService = contactBoxService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactBoxService.GetListAll();
            return View(values);
        }
    }
}
