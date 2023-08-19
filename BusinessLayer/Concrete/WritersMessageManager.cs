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
    public class WritersMessageManager : IWritersMessageService
    {
        private readonly IWritersMessageDAL _writersMessageDAL;

        public WritersMessageManager(IWritersMessageDAL writersMessageDAL)
        {
            _writersMessageDAL = writersMessageDAL;
        }

        public void Delete(WritersMessage t)
        {
            _writersMessageDAL.Delete(t);
        }

        public WritersMessage Get(Expression<Func<WritersMessage, bool>> filter)
        {
            return _writersMessageDAL.Get(filter);
        }

        public WritersMessage GetById(int id)
        {
            return _writersMessageDAL.GetById(id);
        }

        public List<WritersMessage> GetListAll(Expression<Func<WritersMessage, bool>> filter = null)
        {
           return _writersMessageDAL.GetListAll(filter);
        }

        public List<WritersMessage> GetListReceiverMessage(string mail)
        {
            return _writersMessageDAL.GetListAll(a => a.Receiver == mail);
        }

        public List<WritersMessage> GetListSenderMessage(string mail)
        {
            return _writersMessageDAL.GetListAll(a => a.Sender == mail);
        }

        public void Insert(WritersMessage t)
        {
            _writersMessageDAL.Insert(t);
        }

        public void Update(WritersMessage t)
        {
            _writersMessageDAL.Update(t);
        }
    }
}
