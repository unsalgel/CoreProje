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

namespace CoreProje.ViewComponents.Skill
{
    public class SkillList:ViewComponent
    {
        SkillManager sm = new SkillManager(new EfSkillDAL());
        public IViewComponentResult Invoke()
        {
            var values=sm.TGetList();   
            return View(values);  
        }
    }
}
