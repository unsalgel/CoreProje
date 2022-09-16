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
    public class PortfolioManager : IGenericServices<Portfolio>
    {
        IPortfolioDAL _portfolioDAL;

        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
            _portfolioDAL = portfolioDAL;
        }

        public void TAdd(Portfolio t)
        {
            _portfolioDAL.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfolioDAL.Delete(t);
        }

        public List<Portfolio> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Portfolio> TGetByFilterList(Expression<Func<Portfolio, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Portfolio TGetByID(int id)
        {
            return _portfolioDAL.GetByID(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioDAL.GetList();
        }

        public void TUpdate(Portfolio t)
        {
            _portfolioDAL.Update(t);
        }
    }
}
