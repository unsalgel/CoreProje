using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq;
namespace CoreProje.Controllers
{
	public class WriterUserController : Controller
	{
		WriterUserManager wm = new WriterUserManager(new EfWriterUserDAL());
		
		public IActionResult Index()
		{

			return View();
		}
		public IActionResult ListUser()
		{
            var values = JsonConvert.SerializeObject(wm.TGetList());
			return Json(values);
        }
		public IActionResult AddUser(WriterUser p)
		{
			wm.TAdd(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}
    }
}
