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
    public class TestimonialManager : ITestimonialServices
    {
        ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void TAdd(Testimonial t)
        {
                _testimonialDAL.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDAL.Delete(t);  
        }

        public List<Testimonial> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> TGetByFilterList(Expression<Func<Testimonial, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetByID(int id)
        {
                return _testimonialDAL.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
           return _testimonialDAL.GetList();
        }

        public void TUpdate(Testimonial t)
        {
            _testimonialDAL.Update(t);
         }
    }
}
