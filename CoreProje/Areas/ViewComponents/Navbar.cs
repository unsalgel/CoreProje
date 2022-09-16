using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using DataAccesLayer.Concrete;
using CoreProje.Areas.Writer.Models;

namespace CoreProje.Areas.ViewComponents
{
    public class Navbar:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public Navbar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
           var values = _userManager.FindByNameAsync(User.Identity.Name).Result; 
            ViewBag.image = values.ImageURL;
            return View();
        }
    }
}
