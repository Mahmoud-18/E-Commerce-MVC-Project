using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class Shop : Controller
    {
        IProductRepository _productRepository;
        public Shop (IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
    }
}
