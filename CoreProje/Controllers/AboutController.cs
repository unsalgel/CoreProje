using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDAL());
        [HttpGet]

        public IActionResult Index()
        {
            
            var values=am.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About a)
        {
            am.TUpdate(a);
            return RedirectToAction("Index", "Default");
        }
    }
}
