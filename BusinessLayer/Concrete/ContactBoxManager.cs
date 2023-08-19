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
    public class ContactBoxManager : IContactBoxService
    {
        private readonly IContactBoxDAL _contactBoxDAL;

        public ContactBoxManager(IContactBoxDAL contactBoxDAL)
        {
            _contactBoxDAL = contactBoxDAL;
        }

        public void Delete(ContactBox t)
        {
            _contactBoxDAL.Delete(t);
        }

        public ContactBox Get(Expression<Func<ContactBox, bool>> filter)
        {
            return _contactBoxDAL.Get(filter);
        }

        public ContactBox GetById(int id)
        {
            return _contactBoxDAL.GetById(id);
        }

        public List<ContactBox> GetListAll(Expression<Func<ContactBox, bool>> filter = null)
        {
            return _contactBoxDAL.GetListAll(filter);
        }

        public void Insert(ContactBox t)
        {
            _contactBoxDAL.Insert(t);
        }

        public void Update(ContactBox t)
        {
            _contactBoxDAL.Update(t);
        }
    }
}
