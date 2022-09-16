using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Abstract;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfFeatureDAL:GenericRepository<Feature>,IFeatureDAL
    {
    }
}
