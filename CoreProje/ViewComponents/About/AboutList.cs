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

namespace CoreProje.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        AboutManager ab = new AboutManager(new EfAboutDAL());
        public IViewComponentResult Invoke()
        {
            var values = ab.TGetList();
            return View(values);    
        }
    }
}
