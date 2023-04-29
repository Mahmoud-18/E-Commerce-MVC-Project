using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.Services;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ShopController : Controller
    {     
        ProductsServices ProductsServices;

        public ShopController (ProductsServices productsServices)
        {
            ProductsServices = productsServices;
        }
        public IActionResult ShowAllProducts()
        {
            var products = ProductsServices.GetAllProducts();
            return View(products);
        }
        public IActionResult ProductsByCategory(int id)
        {
            var products = ProductsServices.GetProductsByCategoryId(id);
            return View(products);
        }
    }
}
