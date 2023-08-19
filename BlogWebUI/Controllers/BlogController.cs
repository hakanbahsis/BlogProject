using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var values = _blogService.GetBlogListWithCategory();
            return View(values);
        }

		[HttpGet]
		public IActionResult BlogDetails(int id)
		{
			var values = _blogService.GetBlogByID(id);
			Context c = new Context();
			var val = c.Comments.Where(p => p.BlogID == id).Count();
			ViewBag.val = val;
			return View(values);
		}
		public PartialViewResult BlogDetailsSideBar()
		{

			return PartialView();
		}
	}
}
