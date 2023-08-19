
using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDAL : IGenericDal<Blog>
    {
        // include ile  ettigim categoryle beraber listelemek için bu kodu yazdım
        List<Blog> GetBlogListWithCategory();
        //   List<Blog> GetBlogByID(int WriterID);
        List<Blog> GetBlogListWriter(Expression<Func<Blog, bool>> filter);
        public Blog GetBlogCategory(int id);
    }
}
