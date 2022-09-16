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
    public class ContactManager : IGenericServices<Contact>
    {
        IContactDAL _contactDAL;
     public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void TAdd(Contact t)
        {
            _contactDAL.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contactDAL.Delete(t);
        }

        public List<Contact> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetByFilterList(Expression<Func<Contact, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Contact TGetByID(int id)
        {
            return _contactDAL.GetByID(id);
        }

        public List<Contact> TGetList()
        {
            return _contactDAL.GetList();
        }

        public void TUpdate(Contact t)
        {
            _contactDAL.Update(t);
        }
    }
}
