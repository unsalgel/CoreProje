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


namespace CoreProje.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDAL());
  
        public IViewComponentResult Invoke()
        {
            var values = fm.TGetList();
            return View(values);
        }
    }
}
