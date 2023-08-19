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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDAL _blogDAL;

        public BlogManager(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }

        public List<Blog> AdminGetList()
        {
            return _blogDAL.GetListAll().OrderByDescending(x=>x.BlogID).ToList();
        }

        public void Delete(Blog t)
        {
            _blogDAL.Delete(t);
        }

        public Blog Get(Expression<Func<Blog, bool>> filter)
        {
           return _blogDAL.Get(filter);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDAL.GetBlogListWriter(p => p.BlogID == id);

        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDAL.GetBlogListWithCategory().Where(p=>p.Category.CategoryStatus==true).OrderByDescending(x=>x.BlogID).ToList();
        }

        public List<Blog> GetBlogListWriter(int WriterID)
        {
            return _blogDAL.GetBlogListWriter(p => p.WriterID == WriterID).OrderByDescending(p => p.BlogID).ToList();
            
        }

        public Blog GetById(int id)
        {
            return _blogDAL.GetById(id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDAL.GetListAll().OrderByDescending(p => p.BlogID).Take(3).ToList();
        }

        public List<Blog> GetListAll(Expression<Func<Blog, bool>> filter)
        {
            return _blogDAL.GetListAll(filter);
        }

        public void Insert(Blog t)
        {
            _blogDAL.Insert(t);
        }

        public void Update(Blog t)
        {
           _blogDAL.Update(t);
        }
    }
}
