using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDAL<T> where T : class 
    {
       void Insert(T t);   
       void Delete(T t);   
       void Update(T t);
        List<T> GetList(); 
        //ID Ye göre getir
        T GetByID(int id);
        //şarta göre listeleme methodu
        List<T> GetByFilterList(Expression<Func<T, bool>> filter);

    }
    
}
