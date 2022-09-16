using BusinessLayer.Concrete;
using CoreProje.Models;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoreProje.Controllers
{
    [AllowAnonymous]
    public class ResetPasswordController : Controller
    {
        readonly UserManager<WriterUser> _userManager;
        readonly SignInManager<WriterUser> _signInManager;

        public ResetPasswordController(UserManager<WriterUser> userManager, SignInManager<WriterUser> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }
        [HttpGet]
        public IActionResult PasswordReset()
        {
            return View();
        }
       [HttpPost]
        public async Task<IActionResult> PasswordReset(ResetPasswordViewModel model)
        {
            WriterUser User = await _userManager.FindByEmailAsync(model.Email);
            if (User != null)
            {
                string resetToken=await _userManager.GeneratePasswordResetTokenAsync(User);
                byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(resetToken);
                var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);
                MailMessage mail=new MailMessage();
                mail.IsBodyHtml= true;  
                mail.To.Add(User.Email);
                mail.From=new MailAddress("Mail adresiniz", "Şifre Güncelleme", System.Text.Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:44308{Url.Action("UpdatePassword", "ResetPassword", new { userId = User.Id, token = codeEncoded })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials=new NetworkCredential("Mail Adresiniz", "Şifreniz");
                smtpClient.Port=587;
                smtpClient.Host="smtp-mail.outlook.com";
                smtpClient.EnableSsl=true;
                smtpClient.Send(mail);
                ViewBag.State = true;
            }
            else
                ViewBag.State = false;
       
            return View();
        }
   
        [HttpGet("[controller]/[action]/{userID}/{Token}")]
        public IActionResult UpdatePassword(string userID, string Token)
        {
         
            return View();
        }
      
        [HttpPost("[controller]/[action]/{userID}/{Token}")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel model,string userID, string Token)
        {
            WriterUser user = await _userManager.FindByIdAsync(userID);
            var codeDecodedBytes = WebEncoders.Base64UrlDecode(Token);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, codeDecoded, model.Password);
            if (result.Succeeded)
            {
                ViewBag.State = true;
                await _userManager.UpdateSecurityStampAsync(user);
            }
            else
                ViewBag.State = false;
            return View();
        }
    }
}

