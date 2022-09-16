using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CoreProje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace CoreProje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.SurName = values.SurName;
            model.PictureURL = values.ImageURL;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel u)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (u.Picture != null)
            {
                //yolu aldık
                var resoure = Directory.GetCurrentDirectory();
                //uzantıyı aldık
                var extension = Path.GetExtension(u.Picture.FileName);
                //resim ismi guid benzersiz bir resim ismi tanımlamak için kullandıgım bir method
                var imagename = Guid.NewGuid() + extension;
                //resmin kaydedileceği yer
                var savelocation = resoure + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await u.Picture.CopyToAsync(stream);
                user.ImageURL = imagename;
            }
            user.Name = u.Name;
            user.SurName = u.SurName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, u.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
