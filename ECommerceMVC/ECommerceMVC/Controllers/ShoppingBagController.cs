using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ShoppingBagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
