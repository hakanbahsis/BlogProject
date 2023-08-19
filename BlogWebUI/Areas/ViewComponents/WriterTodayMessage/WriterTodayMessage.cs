using BlogWebUI.Areas.Writer.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.ViewComponents.WriterTodayMessage
{
    public class WriterTodayMessage : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly IWritersMessageService _writersMessageService;
        public WriterTodayMessage(UserManager<WriterUser> userManager, IWritersMessageService writersMessageService)
        {
            _userManager = userManager;
            _writersMessageService = writersMessageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string mail;
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            mail = values.Email;
            DateTime date = DateTime.Now.Date;
            Context c = new Context();
            var message = (from item in c.Users
                           join y in c.WritersMessages on item.Email equals y.Sender
                           where y.Receiver == mail
                           select new WriterImage
                           {
                               ImageUrl = item.ImageURL,
                               Date = y.Date,
                               SenderName = y.SenderName,
                               MessageContent = y.MessageContent,
                               ID = y.ID,
                               Receiver = y.Receiver
                           }).Where(a => a.Date == date).ToList();

            return View(message);
        }
    }
}
