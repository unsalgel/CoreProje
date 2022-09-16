using BusinessLayer.Concrete;
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
namespace CoreProje.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.SkillCount = c.Skills.Count();
            //okunmamış mesaj sayısı
            ViewBag.MessageCountfalse = c.Messages.Where(p=>p.Status==false).Count();
            //okunmuş mesaj sayısı
            ViewBag.MessageCounttrue = c.Messages.Where(p=>p.Status==true).Count();
            ViewBag.ExperienceCount = c.Experiences.Count();
            return View();  
        }
    }
}
