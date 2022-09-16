using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace CoreProje.Controllers
{
    public class AdminMessageController : Controller
    {

        WriterMessageManager wm = new WriterMessageManager(new EfWriterMessageDAL());
        [Authorize(Roles = "Admin")]
        public IActionResult ReceiverMessageList(string p)
        {
            TempData["Redirect"]="ReceiverMessageList";
            p="admin@gmail.com";
            var values = wm.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList(string p)
        {
            TempData["Redirect"]="SenderMessageList";
            p="admin@gmail.com";
            var values = wm.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var redirecturl = TempData["Redirect"].ToString();
            var values = wm.TGetByID(id);
            wm.TDelete(values);
            return RedirectToAction(redirecturl);
        }
        [HttpGet]
        public IActionResult AdminSendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminSendMessage(WriterMessage p)
        {
            Context c = new Context();
            var username = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            p.ReceiverName = username;
            wm.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values=wm.TGetByID(id);
            return View(values);
        }
    }
}
