using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/Comment")]

    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _commentService.GetCommentList();
            return View(values);
        }
        //Yorumu Onayla
        [Route("")]
        [Route("CommentStatusTrue/{id}")]
        public IActionResult CommentStatusTrue(int id)
        {
            Context c = new Context();
            var commentstatustrue = c.Comments.Find(id);
            commentstatustrue.CommentStatus = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        //Yorumu Gizle
        [Route("")]
        [Route("CommentStatusFalse/{id}")]
        public IActionResult CommentStatusFalse(int id)
        {
            Context c = new Context();
            var commentstatustrue = c.Comments.Find(id);
            commentstatustrue.CommentStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("")]
        [Route("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var deletecomment = _commentService.GetById(id);
            _commentService.Delete(deletecomment);
            return RedirectToAction("Index");
        }
    }
}
