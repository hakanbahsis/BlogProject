using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{

   [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Announcements")]
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        [Route("")]
        [Route("Announcements")]
        public IActionResult Announcements()
        {
            var values = _announcementsService.GetListAll();
            return View(values);
        }
        [Route("")]
        [Route("DeleteAnnouncements/{id}")]
        public IActionResult DeleteAnnouncements(int id)
        {
            var values = _announcementsService.GetById(id);
            _announcementsService.Delete(values);
            return RedirectToAction("Announcements");
        }
        [Route("")]
        [Route("AddAnnouncements")]
        public IActionResult AddAnnouncements(Announcements a)
        {
            _announcementsService.Insert(a);
            return RedirectToAction("Announcements");

        }
    }
}
