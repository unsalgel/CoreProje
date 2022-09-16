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
    public class FeatureManager : IGenericServices<Feature>
    {
        IFeatureDAL _featureDAL;

        public FeatureManager(IFeatureDAL featureDAL)
        {
            _featureDAL = featureDAL;
        }

        public void TAdd(Feature t)
        {
            _featureDAL.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDAL.Delete(t);
        }

        public List<Feature> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Feature> TGetByFilterList(Expression<Func<Feature, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Feature TGetByID(int id)
        {
           return _featureDAL.GetByID(id);  
        }

        public List<Feature> TGetList()
        {
            return _featureDAL.GetList();   
        }

        public void TUpdate(Feature t)
        {
          _featureDAL.Update(t);    
        }
    }
}
