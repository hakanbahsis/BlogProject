using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Announcement")]

    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        [Route("")]
        [Route("AnnouncementDetails/{id}")]
        public IActionResult AnnouncementDetails(int id)
        {
            var values = _announcementsService.GetById(id);
            return View(values);
        }
    }
}
