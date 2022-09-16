using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccesLayer.Concrete;

namespace CoreProje.Areas.ViewComponents
{
    public class Notification:ViewComponent
    {
        AnnouncementManager am = new AnnouncementManager(new EfAnnouncementDAL());
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var announcementsNow = c.Announcements.Where(p => p.Date== tarih).ToList();
            return View(announcementsNow);
        }
    }
}
