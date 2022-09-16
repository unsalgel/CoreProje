using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class UserListController : Controller
    {
        WriterUserManager wm = new WriterUserManager(new EfWriterUserDAL());
      
        public IActionResult Index()
        {
            var values = wm.TGetList();
            return View(values);
        }
    }
}
