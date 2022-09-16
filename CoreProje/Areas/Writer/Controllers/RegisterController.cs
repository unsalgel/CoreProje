using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CoreProje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoreProje.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser w = new WriterUser()
                {
                    Name = p.Name,
                    SurName = p.SurName,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageURL = p.ImageURL
                };
               
                if (p.Password == p.ConfirmPassword)
                {
                    // async method kullanıdgımız için index methodu da async olmaalı ve Task olmalı
                    var result = await _userManager.CreateAsync(w, p.Password); //passwordu veritabanına kaydeder
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                          
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }

            return View(p);
        }
    }

}