using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CoreProje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;

namespace CoreProje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;

        public LoginController(SignInManager<WriterUser> signInManager)
        {
            _signInManager=signInManager;
        }

        //private readonly UserManager<WriterUser> _userManager;
        //private readonly RoleManager<WriterRole> _RoleManager;


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
        
            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {           
                        return RedirectToAction("Index", "Profile", new { area = "Writer" });             
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre girdiniz.");
                }
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Beş defa hatalı giriş denemesinde bulunduğunuz için hesabınız kilitlenmiştir.");
            }
            return View();

        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");

        }
    }
}
