using Microsoft.AspNetCore.Mvc;

namespace vue3.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
