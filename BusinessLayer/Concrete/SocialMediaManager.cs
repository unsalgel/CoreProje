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
    public class SocialMediaManager:IGenericServices<SocialMedia>
    {
        ISocialMediaDAL _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL=socialMediaDAL;
        }

        public void TAdd(SocialMedia t)
        {
         _socialMediaDAL.Insert(t); 
        }

        public void TDelete(SocialMedia t)
        {
           _socialMediaDAL.Delete(t);
        }

        //public List<SocialMedia> TGetByFilterList()
        //{
        //    throw new NotImplementedException();
        //}

        public List<SocialMedia> TGetByFilterList(Expression<Func<SocialMedia, bool>> filter)
        {
          return  _socialMediaDAL.GetByFilterList(p=>p.Status==true);
        }

        public SocialMedia TGetByID(int id)
        {
           return _socialMediaDAL.GetByID(id);
        }

        public List<SocialMedia> TGetList()
        {
          return _socialMediaDAL.GetList(); 
        }

        public void TUpdate(SocialMedia t)
        {
        _socialMediaDAL.Update(t);  
        }
    }
}
