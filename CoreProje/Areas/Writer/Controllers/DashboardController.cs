using CoreProje.Areas.Writer.Models;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreProje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
       
        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            var values =  await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = values.Name + " " + values.SurName;
            //istatistik verileri
            Context c = new Context();
            ViewBag.Announcements = c.Announcements.Count();
            ViewBag.Skills = c.Skills.Count();
            ViewBag.ReceiverMessage = c.writerMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.SenderMessage = c.writerMessages.Where(a=>a.Sender==values.Email).Count();
            //Hava durumu apisi
            string api = "15a16172122e64a3858d6f7d16c1531f";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=izmir&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
          
            return View();
        }
    }
}
