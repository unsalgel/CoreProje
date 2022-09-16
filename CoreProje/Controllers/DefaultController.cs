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
    public class DefaultController : Controller
    {
        MessageManager message = new MessageManager(new EfMessageDAL());
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult SendMessage(Message m)
        {
            return PartialView();
        }


        public IActionResult Send(Message m)
        {
            message.TAdd(m);
            var values = JsonConvert.SerializeObject(m);
            return Json(values);
        }
    }



}
