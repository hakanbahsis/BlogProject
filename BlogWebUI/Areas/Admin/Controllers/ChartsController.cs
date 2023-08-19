using BlogWebUI.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Charts")]

    public class ChartsController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("")]
        [Route("Index2")]
        public IActionResult Index2()
        {

            return View();
        }


        [Route("")]
        [Route("VisualizeResult2")]
        public IActionResult VisualizeResult2()
        {
            return Json(CategoryList());
        }

        [Route("")]
        [Route("CategoryList")]
        public List<Chart> CategoryList()
        {
            List<Chart> cs = new List<Chart>();


            using (var c = new Context())
            {
                cs = c.Blogs.Select(x => new Chart
                {
                    title = x.BlogTitle,
                    id = x.BlogID
                }).ToList();
            }
            return cs;
        }

        //Daire grafigi başlangıc
        [Route("")]
        [Route("VisualizeResult")]
        public IActionResult VisualizeResult()
        {
            return Json(BlogList());
        }


        [Route("")]
        [Route("BlogList")]
        public List<Chart> BlogList()
        {
            List<Chart> cs = new List<Chart>();


            using (var c = new Context())
            {
                cs = c.Blogs.Select(x => new Chart
                {
                    title = x.BlogTitle,
                    id = x.BlogID
                }).ToList();
            }
            return cs;
        }
        //Daire grafigi bitiş

    }
}
