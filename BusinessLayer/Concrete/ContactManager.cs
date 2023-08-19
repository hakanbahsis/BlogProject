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
    public class ContactManager : IContactService
    {
        private readonly IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void Delete(Contact t)
        {
            _contactDAL.Delete(t);
        }

        public Contact Get(Expression<Func<Contact, bool>> filter)
        {
            return _contactDAL.Get(filter);
        }

        public Contact GetById(int id)
        {
            return (_contactDAL.GetById(id));
        }

        public List<Contact> GetListAll(Expression<Func<Contact, bool>> filter = null)
        {
            return _contactDAL.GetListAll(filter);
        }

        public void Insert(Contact t)
        {
            _contactDAL.Insert(t);
        }

        public void Update(Contact t)
        {
            _contactDAL.Update(t);
        }
    }
}
