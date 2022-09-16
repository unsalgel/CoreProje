using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementServices
    {
        IAnnouncementDAL _announcementDAL;

        public AnnouncementManager(IAnnouncementDAL announcementDAL)
        {
            _announcementDAL = announcementDAL;
        }

        public void TAdd(Announcement t)
        {
            _announcementDAL.Insert(t);
        }

        public void TDelete(Announcement t)
        {
         _announcementDAL.Delete(t);    
        }

        public List<Announcement> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Announcement> TGetByFilterList(Expression<Func<Announcement, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Announcement TGetByID(int id)
        {
        return  _announcementDAL.GetByID(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementDAL.GetList();
        }

        public void TUpdate(Announcement t)
        {
            _announcementDAL.Update(t);
        }
    }
}
