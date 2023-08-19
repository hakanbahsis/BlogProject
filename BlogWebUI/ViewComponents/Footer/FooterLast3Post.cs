using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.ViewComponents.Footer
{
    public class FooterLast3Post : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly Context _context;

        public FooterLast3Post(IBlogService blogService, Context context)
        {
            _blogService = blogService;
            _context = context;
        }


        public IViewComponentResult Invoke()
        {
            var about = _context.Abouts.Select(x => x.AboutDetails1).FirstOrDefault();
            ViewBag.About = about.ToString();

            var value = _blogService.GetLast3Blog();
            return View(value);
        }
    }
}
