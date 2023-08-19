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
    public class AnnouncementsManager : IAnnouncementsService
    {
        private readonly IAnnouncementsDAL _announcementsDAL;

        public AnnouncementsManager(IAnnouncementsDAL announcementsDAL)
        {
            _announcementsDAL = announcementsDAL;
        }

        public void Delete(Announcements t)
        {
            _announcementsDAL.Delete(t);
        }

        public Announcements Get(Expression<Func<Announcements, bool>> filter)
        {
            return _announcementsDAL.Get(filter);
        }

        public Announcements GetById(int id)
        {
            return _announcementsDAL.GetById(id);
        }

        public List<Announcements> GetListAll(Expression<Func<Announcements, bool>> filter)
        {
            return _announcementsDAL.GetListAll(filter);    
        }

        public void Insert(Announcements t)
        {
            _announcementsDAL.Insert(t);
        }

        public void Update(Announcements t)
        {
           _announcementsDAL.Update(t);
        }
    }
}
