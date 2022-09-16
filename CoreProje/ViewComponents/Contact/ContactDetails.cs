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

namespace CoreProje.ViewComponents.Contact
{
    public class ContactDetails:ViewComponent
    {
        ContactManager cm = new ContactManager(new EfContactDAL());
       public IViewComponentResult Invoke()
        {
            var values = cm.TGetList(); 
            return View(values);  
        }
    }
}
