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

namespace CoreProje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDAL());
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
            var values=sm.TGetList();
          return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill s)
        {
            sm.TAdd(s);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var values = sm.TGetByID(id);
            sm.TDelete(values);
            return RedirectToAction("Index"); 
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
       
            var values = sm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill u)
        {  
            sm.TUpdate(u);
            return RedirectToAction("Index"); 
        }

    }
}
