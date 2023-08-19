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
    public class WriterManager : IWriterService
    {
        private readonly IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public void Delete(Writer t)
        {
            _writerDAL.Delete(t);
        }

        public Writer Get(Expression<Func<Writer, bool>> filter)
        {
          return _writerDAL.Get(filter);
        }

        public Writer GetById(int id)
        {
            return _writerDAL.GetById(id);
        }

        public List<Writer> GetListAll(Expression<Func<Writer, bool>> filter = null)
        {
            return _writerDAL.GetListAll(filter);
        }

        public void Insert(Writer t)
        {
            _writerDAL.Insert(t);
        }

        public void Update(Writer t)
        {
            _writerDAL.Update(t);
        }
    }
}
