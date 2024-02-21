using Microsoft.AspNetCore.Mvc;

namespace vue3.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            var jsonData = new[]
            {
                new { Id = 1, Name = "Item 1", Description = "Description for Item 1" },
                new { Id = 2, Name = "Item 2", Description = "Description for Item 2" },
            };
            return Ok(jsonData);
        }
    }
}
