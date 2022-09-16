using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreProje.Controllers
{
    public class AdminController : Controller
    {
        PortfolioManager pm = new PortfolioManager(new EfPortfolioDAL());
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavigation()
        {
            return PartialView();
        }
        public PartialViewResult NewSidebar()
        {
            return PartialView();
        }
  

    }
}
