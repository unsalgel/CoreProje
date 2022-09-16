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

namespace CoreProje.Models
{
    public class WriterImage
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string SenderName { get; set; }
        public string Receiver { get; set; }
        public string MessageContent { get; set; }
        public string ImageUrl { get; set; }
       
      
    }
}
