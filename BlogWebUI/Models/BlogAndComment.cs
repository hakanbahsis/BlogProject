using EntityLayer.Concrete;

namespace BlogWebUI.Models
{
    public class BlogAndComment
    {
        public IEnumerable<Blog> Value1 { get; set; }
        public IEnumerable<Comment> Value2 { get; set; }
    }
}
