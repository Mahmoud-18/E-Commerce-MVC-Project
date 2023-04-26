using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class Shop : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
