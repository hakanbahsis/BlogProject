using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebUI.ViewComponents.WriterPost
{
    public class WriterPostList : ViewComponent
    {
        private readonly IBlogService _blogService;

        public WriterPostList(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int WriterID)
        {

            var value = _blogService.GetBlogListWriter(WriterID);
            return View(value);
        }
    }
}
