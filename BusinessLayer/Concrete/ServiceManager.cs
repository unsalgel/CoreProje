using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IGenericServices<Service>
    {
        IServiceDAL _servicesServices;
       

        public ServiceManager(IServiceDAL servicesServices)
        {
            _servicesServices = servicesServices;       
        }

        public void TAdd(Service t)
        {
           _servicesServices.Insert(t); 
        }

        public void TDelete(Service t)
        {
                _servicesServices.Delete(t);    
        }

        public List<Service> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Service> TGetByFilterList(Expression<Func<Service, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Service TGetByID(int id)
        {
            return _servicesServices.GetByID(id);   
        }

        public List<Service> TGetList()
        {
             return _servicesServices.GetList();    
        }

        public void TUpdate(Service t)
        {
            _servicesServices.Update(t);    
        }
    }
}
