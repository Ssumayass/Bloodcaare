using Microsoft.AspNetCore.Mvc;

namespace BloodCare.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Lägg till dina andra action-metoder här

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
