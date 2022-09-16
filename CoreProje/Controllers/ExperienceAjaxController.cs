using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CoreProje.Controllers
{
    public class ExperienceAjaxController : Controller
    {
        ExperienceManager em = new ExperienceManager(new EfExperienceDAL());
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(em.TGetList());
            return Json(values);
        }
        public IActionResult AddExperience(Experience p)
        {
            em.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetByID(int ExperienceID)
        {
            var valueid = em.TGetByID(ExperienceID);
            var values = JsonConvert.SerializeObject(valueid);
            return Json(values);
        }
        public ActionResult DeleteExperience(int id)
        {
            var values = em.TGetByID(id);
            em.TDelete(values);
            return Ok();
        }
        [HttpPost]
        public ActionResult EditExperience(int ExperienceID, string Name)
        {
            var values = em.TGetByID(ExperienceID);

            if (values!=null)
            {
                values.Name=Name;
              
                values.Date=DateTime.Now.Date;
                em.TUpdate(values);
                var values2 = JsonConvert.SerializeObject(values);
                return Json(values2);

            }
            else
            {
                return View();
            }

        }
    }
}
