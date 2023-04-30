using ECommerceMVC.Context;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerceMVC.Controllers
{
    public class SearchController : Controller
    {
        EcommerceDbContext db=new EcommerceDbContext();
        public IActionResult Index(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return View();
            }

            var products = db.Product.Where(p => p.Name.Contains(s));
            return View(products);
        }
    }
}
