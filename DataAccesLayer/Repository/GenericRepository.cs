using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();    
        }
        //şarta göre listeleme
        public List<T> GetByFilterList(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();   
        }

        // ID  ye göre arama işlemi
        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
           
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }


        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges(true);
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }

}
