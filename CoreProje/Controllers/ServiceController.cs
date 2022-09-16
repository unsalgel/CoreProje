using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager fm = new ServiceManager(new EfServiceDAL());
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
          
            var values = fm.TGetList();
            return View(values);
        }
        public IActionResult DeleteService(int id)
        {
            var values = fm.TGetByID(id);
            fm.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddService(Service s)
        {
            fm.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        { 
            var values=fm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service s)
        {
            fm.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}
