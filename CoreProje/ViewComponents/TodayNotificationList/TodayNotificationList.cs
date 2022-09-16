using BusinessLayer.Concrete;
using CoreProje.Models;
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

namespace CoreProje.ViewComponents.TodayNotificationList
{
    public class TodayNotificationList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            DateTime Today = DateTime.Now.Date;
            var values = c.Announcements.Where(p => p.Date==Today).ToList();
            return View(values);  
        }
    }
}
