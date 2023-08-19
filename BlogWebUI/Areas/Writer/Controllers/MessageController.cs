using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        private readonly IWritersMessageService _messageService;
        private readonly IWriterUserService _writerUserService;
        public MessageController(UserManager<WriterUser> userManager, IWritersMessageService messageService, IWriterUserService writerUserService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _writerUserService = writerUserService;
        }

        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            List<SelectListItem> WriterList = (from i in _writerUserService.GetListAll()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Email
                                               }).ToList();
            ViewBag.WriterList = WriterList;

            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WritersMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //Gönderici bilgileri
            string mail = values.Email;
            string name = values.Name;
            p.Sender = mail;
            p.SenderName = name;
            //Alıcı bilgileri
            Context c = new Context();
            var username = c.Users.Where(a => a.Email == p.Receiver).Select(y => y.Name).FirstOrDefault();
            p.ReceiverName = username;
            _messageService.Insert(p);
            return RedirectToAction("WriterBlogList", "ControlPanel", new { Area = "Writer" });
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var sendermessagelist = _messageService.GetListSenderMessage(p);
            return View(sendermessagelist);
        }
        [Route("")]
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            var values = _messageService.GetById(id);
            return View(values);
        }
        [Route("")]
        [Route("MessageDetails2/{id}")]
        public IActionResult MessageDetails2(int id)
        {
            var values = _messageService.GetById(id);
            return View(values);
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var receivermessagelist = _messageService.GetListReceiverMessage(p);
            return View(receivermessagelist);
        }

    }
}
