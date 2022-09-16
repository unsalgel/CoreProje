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
    public class StatisticsDashboard:ViewComponent
    {
        Context c  = new Context(); 
        public IViewComponentResult Invoke()
        {
            ViewBag.portfoliocount = c.Portfolios.Count();
            ViewBag.messagecount = c.Messages.Count();
            ViewBag.servicecount = c.Services.Count();

            return View();  
        }
    }
}
