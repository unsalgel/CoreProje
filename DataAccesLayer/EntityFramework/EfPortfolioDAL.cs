using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccesLayer.Abstract;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfPortfolioDAL:GenericRepository<Portfolio>,IPortfolioDAL   
    {
    }
}
