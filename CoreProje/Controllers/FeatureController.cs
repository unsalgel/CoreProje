using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager fm=new FeatureManager(new EfFeatureDAL());
        [Authorize(Roles = "Admin, Moderator")]
        [HttpGet]
        public IActionResult Index()
        {
            var values=fm.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Feature f)
        {
            fm.TUpdate(f);
            return RedirectToAction("Index","Default");
        }

    }
}
