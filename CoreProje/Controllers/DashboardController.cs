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
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace CoreProje.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class DashboardController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDAL());

        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View();
        }
    }
}
