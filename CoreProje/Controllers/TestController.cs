using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
