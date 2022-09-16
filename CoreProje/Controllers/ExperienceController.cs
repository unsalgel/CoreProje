using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CoreProje.Controllers
{
   
    public class ExperienceController : Controller
    {
        ExperienceManager em = new ExperienceManager(new EfExperienceDAL());
        [Authorize(Roles = "Admin, Moderator")]
       
        public IActionResult Index()
        {
            
            var values = em.TGetList();
            return View(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var values = em.TGetByID(id);
            em.TDelete(values); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience e)
        {
            em.TAdd(e);
            return RedirectToAction("Index");    
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
             
            var values=em.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience e)
        {
            em.TUpdate(e);
            return RedirectToAction("Index");
        }

    }
}
