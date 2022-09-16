using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace CoreProje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        
        private readonly UserManager<WriterUser> _userManager;
        WriterMessageManager wm = new WriterMessageManager(new EfWriterMessageDAL());
        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
 
            WriterMessageManager wm = new WriterMessageManager(new EfWriterMessageDAL());
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = wm.GetListReceiverMessage(p);
            return View(messagelist);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {

          
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messagelist = wm.GetListSenderMessage(p);
            return View(messagelist);
        }
        //Gönderici detay
        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            var values = wm.TGetByID(id);
            return View(values);
        }
        //alıcı detay
        [Route("MessageDetails2/{id}")]
        public IActionResult MessageDetails2(int id)
        {
            var values = wm.TGetByID(id);
            return View(values);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail= values.Email;
            string name = values.Name+" "+values.SurName;
            p.Sender = mail;
            p.SenderName = name;
            //Alıcının ismini çekme
            Context c = new Context();
            var username = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            p.ReceiverName = username;
            wm.TAdd(p);
            return RedirectToAction("SenderMessage");
        }

    }
}
