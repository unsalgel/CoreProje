using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;

namespace CoreProje.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager sm = new SocialMediaManager(new EfSocialMediaDAL());
        [Authorize(Roles = "Admin, Moderator")]

        public IActionResult Index()
        {
            var values = sm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values = sm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia s)
        {
            sm.TUpdate(s);
            return RedirectToAction("Index");
        }
        //Sosyal medya durumunu aktifleştirme
        public IActionResult SocialMediaTrue(int id)
        {
            Context c = new Context();
            var durum = c.SocialMedias.Find(id);
            durum.Status=true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SocialMediaFalse(int id)
        {
            Context c = new Context();
            var durum = c.SocialMedias.Find(id);
            durum.Status=false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
