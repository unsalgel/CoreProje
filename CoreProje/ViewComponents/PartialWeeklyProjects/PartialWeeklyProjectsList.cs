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


namespace CoreProje.ViewComponents.PartialWeeklyProjects
{
    public class PartialWeeklyProjectsList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            DateTime today = DateTime.Now;
            DateTime day = today.AddDays(-8);
            var values = c.Portfolios.Where(p => p.Date>=day).ToList();
            return View(values);
           
        }
    }
}
