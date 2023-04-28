using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

     
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       

    }
}