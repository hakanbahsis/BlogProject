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
    public class NewsLetterManager : INewsLetterService
    {
        private readonly INewsLetterDAL _newsLetterDAL;

        public NewsLetterManager(INewsLetterDAL newsLetterDAL)
        {
            _newsLetterDAL = newsLetterDAL;
        }

        public void Delete(NewsLetter t)
        {
            _newsLetterDAL.Delete(t);
        }

        public NewsLetter Get(Expression<Func<NewsLetter, bool>> filter)
        {
            return _newsLetterDAL.Get(filter);
        }

        public NewsLetter GetById(int id)
        {
            return _newsLetterDAL.GetById(id);
        }

        public List<NewsLetter> GetListAll(Expression<Func<NewsLetter, bool>> filter = null)
        {
            return _newsLetterDAL.GetListAll(filter);
        }

        public void Insert(NewsLetter t)
        {
            _newsLetterDAL.Insert(t);
        }

        public void Update(NewsLetter t)
        {
            _newsLetterDAL.Update(t);
        }
    }
}
