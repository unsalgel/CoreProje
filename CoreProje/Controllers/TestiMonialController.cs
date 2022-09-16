using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Newtonsoft.Json;

namespace CoreProje.Controllers
{
    public class TestiMonialController : Controller
    {
        TestimonialManager tm = new TestimonialManager(new EfTestimonialDAL());
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
            var values = tm.TGetList();
            return View(values);
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values=tm.TGetByID(id);
            tm.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult AddTestimonial(Testimonial t)
        {
            tm.TAdd(t);
            var values = JsonConvert.SerializeObject(t);
            return Json(values);
            
        }


        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = tm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial t)
        {
            tm.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
