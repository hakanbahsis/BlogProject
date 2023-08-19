using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Blog")]

    public class BlogController : Controller
    {
        
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _blogService.AdminGetList();
            return View(values);
        }

        [Route("")]
        [Route("DeleteBlog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var deleteblog = _blogService.GetById(id);
            _blogService.Delete(deleteblog);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("EditBlog/{id}")]
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> BlogCategory = (from i in _categoryService.GetListAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.CategoryName,
                                                     Value = i.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.blogcategory = BlogCategory;
            var values = _blogService.GetById(id);
            return View(values);
        }

        [Route("")]
        [Route("EditBlog/{id}")]
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            _blogService.Update(b);
            return RedirectToAction("Index");
        }
    }
}

