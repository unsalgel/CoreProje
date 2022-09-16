using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProje.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
       // MessageManager message = new MessageManager(new EfMessageDAL());
       
       public IViewComponentResult Invoke()
        {
            return View();  
        }
        //[HttpPost]
        //public IViewComponentResult Invoke(Message m)
        //{
        //    m.Status = true;
        //    m.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    message.TAdd(m);
        //    return View();
        //}
    }
}
