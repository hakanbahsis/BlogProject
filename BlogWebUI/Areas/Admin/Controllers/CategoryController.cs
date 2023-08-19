using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("")]
        [Route("CategoryList")]
        public IActionResult CategoryList()
        {
            var categorylist = _categoryService.GetListAll();
            return View(categorylist);
        }
        //kategori durumu aktifleştirme
        [Route("")]
        [Route("CategoryStatuTrue/{id}")]
        public IActionResult CategoryStatuTrue(int id)
        {
            Context c = new Context();
            var categorystatus = c.Categories.Find(id);
            categorystatus.CategoryStatus = true;
            c.SaveChanges();
            return RedirectToAction("CategoryList", new { Area = ("Admin") });
        }
        //kategori durumu pasifleştirme
        [Route("")]
        [Route("CategoryStatuFalse/{id}")]
        public IActionResult CategoryStatuFalse(int id)
        {
            Context c = new Context();
            var categorystatus = c.Categories.Find(id);
            categorystatus.CategoryStatus = false;
            c.SaveChanges();
            return RedirectToAction("CategoryList", new { Area = ("Admin") });
        }
        [Route("")]
        [Route("EditCategory/{id}")]
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var values = _categoryService.GetById(id);
            return View(values);
        }
        [HttpPost]
        [Route("")]
        [Route("EditCategory/{id}")]
        public IActionResult EditCategory(Category c)
        {
            _categoryService.Update(c);
            return RedirectToAction("CategoryList", new { Area = ("Admin") });
        }
        [Route("")]
        [Route("AddCategory")]
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            _categoryService.Insert(c);
            return RedirectToAction("CategoryList", new { Area = ("Admin") });
        }
    }
}
