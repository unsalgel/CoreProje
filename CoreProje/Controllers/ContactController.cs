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
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CoreProje.Controllers
{
    public class ContactController : Controller
    {

        MessageManager mg = new MessageManager(new EfMessageDAL());
        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index()
        {
            var values = mg.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = mg.TGetByID(id);
            mg.TDelete(values);
            return RedirectToAction("Index");
        }    

        ContactManager cm = new ContactManager(new EfContactDAL());
        [HttpGet]
        public IActionResult SubContact()
        {

            var values = cm.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult SubContact(Contact a)
        {
            cm.TUpdate(a);
            return RedirectToAction("#contact", "Default");
        }
    }
}
