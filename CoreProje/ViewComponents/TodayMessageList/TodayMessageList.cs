using BusinessLayer.Concrete;
using CoreProje.Models;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CoreProje.ViewComponents.TodayMessageList
{
    public class TodayMessageList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            string mail = "admin@gmail.com";
            DateTime Today = DateTime.Now.Date;
            //asp.net users tablosuyla writermessage tablosunu birlestirip verileri çektim resim asp.net users tablosunda oldugu için
            var values = (from item in c.Users
                          join y in c.writerMessages on item.Email equals y.Sender
                          where y.Receiver==mail
                          select new WriterImage
                          {
                              ImageUrl=item.ImageURL,
                              Date=y.Date,
                              SenderName=y.SenderName,
                              MessageContent=y.MessageContent,
                              ID=y.WriterMessageID,
                              Receiver=y.Receiver
                          }).Where(a => a.Date==Today).ToList();

            return View(values);
        }
    }
}
