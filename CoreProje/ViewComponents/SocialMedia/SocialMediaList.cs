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

namespace CoreProje.ViewComponents.SocialMedia
{

    
    //ServiceManager 1 = new ServiceManager(new EfServiceDAL());
    public class SocialMediaList:ViewComponent
    {
        SocialMediaManager sm = new SocialMediaManager(new EfSocialMediaDAL());
        public IViewComponentResult Invoke()
        {
            var values = sm.TGetByFilterList(p=>p.Status==true);
            return View(values);
        }
    }
}
