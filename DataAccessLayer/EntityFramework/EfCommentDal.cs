using CoreLayer.DataAccess;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, Context>, ICommentDAL
    {
        public List<Comment> GetListComment()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(p => p.Blog).ToList();
            }
        }
    }
}
