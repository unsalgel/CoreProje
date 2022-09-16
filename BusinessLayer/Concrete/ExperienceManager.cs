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
    public class ExperienceManager : IExperienceServices
    {
        IExperienceDAL _experienceDAL;

        public ExperienceManager(IExperienceDAL experienceDAL)
        {
            _experienceDAL = experienceDAL;
        }

        public void TAdd(Experience t)
        {
            _experienceDAL.Insert(t);
        }

        public void TDelete(Experience t)
        {
            _experienceDAL.Delete(t);
        }

        public List<Experience> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Experience> TGetByFilterList(Expression<Func<Experience, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Experience TGetByID(int id)
        {
            return _experienceDAL.GetByID(id);
        }

        public List<Experience> TGetList()
        {
            return _experienceDAL.GetList();
        }

        public void TUpdate(Experience t)
        {
            _experienceDAL.Update(t);
        }
    }
}
