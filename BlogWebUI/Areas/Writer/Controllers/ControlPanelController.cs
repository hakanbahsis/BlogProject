using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BlogWebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/ControlPanel")]
    public class ControlPanelController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<WriterUser> _userManager;


        public ControlPanelController(UserManager<WriterUser> userManager, IBlogService blogService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();

        }
        [Route("")]
        [Route("WriterBlogList")]
        public IActionResult WriterBlogList(string user, int page = 1)
        {
            user = User.Identity.Name;
            Context c = new Context();
            var values = c.Blogs.Include(b => b.Category).Where(p => p.WriterUser.UserName == user).ToPagedList(page, 3);
            return View(values);
        }
        [Route("")]
        [Route("DeleteBlog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var values = _blogService.GetById(id);
            _blogService.Delete(values);

            return RedirectToAction("WriterBlogList");
        }
        [HttpGet]
        [Route("")]
        [Route("EditBlog/{id}")]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> BlogCategoryList = (from i in _categoryService.GetListAll()
                                                     select new SelectListItem
                                                     {
                                                         Text = i.CategoryName,
                                                         Value = i.CategoryID.ToString()
                                                     }).ToList();
            ViewBag.BlogCategoryList = BlogCategoryList;
            var values = _blogService.GetById(id);
            return View(values);
        }
        [Route("")]
        [Route("EditBlog/{id}")]
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            b.BlogCreateDate = DateTime.Now;
            _blogService.Update(b);
            return RedirectToAction("WriterBlogList");
        }
        [Route("")]
        [Route("AddBlog")]
        [HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> BlogCategoryList = (from i in _categoryService.GetListAll()
                                                     select new SelectListItem
                                                     {
                                                         Text = i.CategoryName,
                                                         Value = i.CategoryID.ToString()
                                                     }).ToList();
            ViewBag.BlogCategoryList = BlogCategoryList;
            return View();
        }
        [Route("")]
        [Route("AddBlog")]
        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog b)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(b.Image1.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/images/" + imageName;
            using (var stream = new FileStream(saveLocation, FileMode.Create))
            {
                b.Image1.CopyTo(stream);
            }
            b.BlogStatus = true;

            b.BlogThumbnailImage = "/images/" + imageName;
            b.BlogImage = "/images/" + imageName;

            b.BlogCreateDate = DateTime.Now;
            b.WriterID = user.Id;
            _blogService.Insert(b);
            return RedirectToAction("WriterBlogList");
        }
        
        [Route("")]
        [Route("AddBlog2")]
        [HttpPost]
        public async Task<IActionResult> AddBlog2(Blog b)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            b.WriterID = user.Id;
            _blogService.Insert(b);
            return RedirectToAction("WriterBlogList");
        }


        [Route("")]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            string user = User.Identity.Name;
            Context c = new Context();
            var tarih = DateTime.Now.Date;
            var tarih2 = DateTime.Now.AddDays(-7);
            var numberofblogsperweek = c.Blogs.Include(b => b.Category).Where(p => p.BlogCreateDate >= tarih2 && p.BlogCreateDate <= tarih).OrderByDescending(a => a.BlogID).Where(p => p.WriterUser.UserName == user).Count();
            var blogcount = c.Blogs.Where(p => p.WriterUser.UserName == user).Count();
            ViewBag.numberofblogsperweek = numberofblogsperweek;
            ViewBag.blogcount = blogcount;
            var usermail = c.Users.Where(p => p.UserName == user).Select(y => y.Email).FirstOrDefault();
            var todaymessagecount = c.WritersMessages.Where(p => p.Date == tarih).OrderByDescending(p => p.ID).Where(p => p.Receiver == usermail).Count();
            ViewBag.todaymessagecount = todaymessagecount;
            return View();
        }

    }
}
