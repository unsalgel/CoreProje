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

namespace CoreProje.ViewComponents.Experience
{
    public class ExperienceList:ViewComponent
    {
        ExperienceManager em=new ExperienceManager(new EfExperienceDAL());
        public IViewComponentResult Invoke()
        {
            var values = em.TGetList();
            return View(values);
        }
    }
}
