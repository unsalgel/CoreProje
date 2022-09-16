using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
