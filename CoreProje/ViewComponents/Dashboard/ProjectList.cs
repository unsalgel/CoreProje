using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CoreProje.ViewComponents.Dashboard
{
    public class ProjectList:ViewComponent
    {
        PortfolioManager pm = new PortfolioManager(new EfPortfolioDAL());
        public IViewComponentResult Invoke()
        {
           var values= pm.TGetList();
            return View(values);
        }
    }
}
