using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Areas.ViewComponents.WriterTodayMessageList
{
    public class WriterTodayMessageList : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            string user = User.Identity.Name;
            var tarih = DateTime.Now.Date;
            var usermail = c.Users.Where(p => p.UserName == user).Select(y => y.Email).FirstOrDefault();
            var todaymessage = c.WritersMessages.Where(p => p.Date == tarih).OrderByDescending(p => p.ID).Where(p => p.Receiver == usermail).ToList();
            return View(todaymessage);
        }
    }
}
