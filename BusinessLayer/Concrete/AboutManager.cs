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
    public class AboutManager : IAboutServices<About>
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;    
        }

        public void TAdd(About t)
        {
            _aboutDAL.Insert(t);

        }

        public void TDelete(About t)
        {
            _aboutDAL.Delete(t);
        }

        public List<About> TGetByFilterList(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public About TGetByID(int id)
        {
            return _aboutDAL.GetByID(id);   
        }

        public List<About> TGetList()
        {
          return _aboutDAL.GetList();
        }

        public void TUpdate(About t)
        {
          _aboutDAL.Update(t);  
        }
    }
}
