using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogWebUI.Areas.ViewComponents.WriterWeeklyBlogs
{
    public class WriterWeeklyBlogs : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string user = User.Identity.Name;
            Context c = new Context();
            var tarih = DateTime.Now;
            var tarih2 = DateTime.Now.AddDays(-7);
            var values = c.Blogs.Include(b => b.Category).Where(p => p.BlogCreateDate >= tarih2 && p.BlogCreateDate <= tarih).OrderByDescending(a => a.BlogID).Where(p => p.WriterUser.UserName == user).ToList();
            return View(values);
        }
    }
}
