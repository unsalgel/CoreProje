using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation.Results;
using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CoreProje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager pm = new PortfolioManager(new EfPortfolioDAL());
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
            var values=pm.TGetList();   
            return View(values);
        }
        public IActionResult DeletePortfolio(int id)
        {
            var values = pm.TGetByID(id);
            pm.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio p)
        {
            pm.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
           
            var values= pm.TGetByID(id);    
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio p)
        {
            pm.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult PortfolioStatusTrue(int id)
        {
            Context c = new Context();
            var durum = c.Portfolios.Find(id);
            durum.Status=true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PortfolioStatusFalse(int id)
        {
            Context c = new Context();
            var durum = c.Portfolios.Find(id);
            durum.Status=false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
