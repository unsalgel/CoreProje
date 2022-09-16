using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Controllers
{
    public class AnnouncementsController : Controller
    {
        AnnouncementManager am = new AnnouncementManager(new EfAnnouncementDAL());
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Moderator")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminAnnouncementDetails(int id)
        {
            var values = am.TGetByID(id);
            return View(values);
        }
    }
}
