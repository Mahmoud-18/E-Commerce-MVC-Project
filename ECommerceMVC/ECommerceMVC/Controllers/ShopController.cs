using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ShopController : Controller
    {
        IProductRepository _productRepository;
        public ShopController (IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }
        public IActionResult ShowAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
    }
}
