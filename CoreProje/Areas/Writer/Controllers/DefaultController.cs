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

namespace CoreProje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManager am = new AnnouncementManager(new EfAnnouncementDAL());
        public IActionResult Index()
        {
            var values = am.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            var values = am.TGetByID(id);
            return View(values);
        }


    }
}

