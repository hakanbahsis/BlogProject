using CoreLayer.DataAccess;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, Context>, IBlogDAL
    {
        public Blog GetBlogCategory(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(p => p.Category).FirstOrDefault(a => a.BlogID == id);
            }
        }
        //Bloga ait kategoriyi getirmek için include ile çekmek gerek  o yüzden bu kodu yazdım
        public List<Blog> GetBlogListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(b => b.Category).ToList();
            }
        }
        public List<Blog> GetBlogListWriter(Expression<Func<Blog, bool>> filter)
        {
            using (var c = new Context())
            {
                var values = c.Blogs.Where(filter).Include(a => a.WriterUser).ToList();
                return values;
            }
        }
    }
}
