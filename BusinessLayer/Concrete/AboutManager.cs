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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void Delete(About t)
        {
            _aboutDAL.Delete(t);
        }

        public About Get(Expression<Func<About, bool>> filter)
        {
            return _aboutDAL.Get(filter);
        }

        public About GetById(int id)
        {
            return _aboutDAL.GetById(id);
        }

        public List<About> GetListAll(Expression<Func<About, bool>> filter = null)
        {
            return _aboutDAL.GetListAll(filter);
        }

      

        public void Insert(About t)
        {
            _aboutDAL.Insert(t);
        }

        public void Update(About t)
        {
            _aboutDAL.Update(t);
        }
    }
}
