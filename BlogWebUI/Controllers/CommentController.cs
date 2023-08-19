using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogWebUI.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController( ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CommentAdd(int id)
        {
            var values = _commentService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult CommentAdd(Comment c)
        {
            c.UserImage = "/web/images/resimyok.png";
            c.CommentStatus = true;
            _commentService.Insert(c);
            var values = JsonConvert.SerializeObject(c);
            return Json(values);
        }

        public IActionResult CommentList(int BlogID)
        {

            var valueid = _commentService.GetCommentListALL(BlogID);
            var values = JsonConvert.SerializeObject(valueid);

            return Json(values);

        }
    }
}
