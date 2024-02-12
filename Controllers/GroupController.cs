using Microsoft.AspNetCore.Mvc;

namespace vue3.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
