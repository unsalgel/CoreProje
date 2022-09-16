using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProje.ViewComponents.Navbar
{
    public class NavbarList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
