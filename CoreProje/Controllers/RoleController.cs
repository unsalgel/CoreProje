using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
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
using CoreProje.Models;

namespace CoreProje.Controllers
{
    public class RoleController : Controller
    {
        readonly RoleManager<WriterRole> _roleManager;
        readonly UserManager<WriterUser> _userManager;

        public RoleController(RoleManager<WriterRole> roleManager, UserManager<WriterUser> userManager)
        {
            _roleManager=roleManager;
            _userManager=userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        public async Task<IActionResult> CreateRole(string id)
        {
            if (id != null)
            {
                WriterRole role = await _roleManager.FindByIdAsync(id);

                return View(new RoleViewModel
                {
                    Name = role.Name
                });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model, string id)
        {
            IdentityResult result = null;
            if (id != null)
            {
                WriterRole role = await _roleManager.FindByIdAsync(id);
                role.Name = model.Name;
                result = await _roleManager.UpdateAsync(role);
            }
            else
                result = await _roleManager.CreateAsync(new WriterRole { Name = model.Name});

            
            return View();
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            WriterRole role = await _roleManager.FindByIdAsync(id); 
            IdentityResult result = await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> RoleAssign(string id)
        {
            WriterUser user = await _userManager.FindByIdAsync(id);
            List<WriterRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }
        [HttpPost]
        public async Task<ActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            WriterUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("Index", "UserList");
        }
    }
}