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
    public class WriterUserManager : IWriterUserService
    {
        private readonly IWriterUserDAL _writerUserDAL;

        public WriterUserManager(IWriterUserDAL writerUserDAL)
        {
            _writerUserDAL = writerUserDAL;
        }

        public void Delete(WriterUser t)
        {
            _writerUserDAL.Delete(t);
        }

        public WriterUser Get(Expression<Func<WriterUser, bool>> filter)
        {
            return _writerUserDAL.Get(filter);
        }

        public WriterUser GetById(int id)
        {
            return _writerUserDAL.GetById(id);
        }

        public List<WriterUser> GetListAll(Expression<Func<WriterUser, bool>> filter = null)
        {
            return _writerUserDAL.GetListAll(filter);
        }

        public void Insert(WriterUser t)
        {
            _writerUserDAL.Insert(t);
        }

        public void Update(WriterUser t)
        {
            _writerUserDAL?.Update(t);
        }
    }
}
