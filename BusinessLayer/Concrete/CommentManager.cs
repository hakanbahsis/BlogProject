using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDAL _commentDAL;

        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public void Delete(Comment t)
        {
            _commentDAL.Delete(t);
        }

        public Comment Get(Expression<Func<Comment, bool>> filter)
        {
            return _commentDAL.Get(filter);
        }

        public Comment GetById(int id)
        {
            return _commentDAL.GetById(id);
        }

        public List<Comment> GetCommentList()
        {
            return _commentDAL.GetListComment();
        }

        public List<Comment> GetCommentListALL(int id)
        {
            return _commentDAL.GetListAll(p => p.BlogID == id).Where(p => p.CommentStatus == true).ToList();
        }

        public List<Comment> GetListAll(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDAL.GetListAll(filter);
        }

        public void Insert(Comment t)
        {
            _commentDAL.Insert(t);
        }

        public void Update(Comment t)
        {
           _commentDAL.Update(t);
        }
    }
}
