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

            //const int pageSize = 5;
            //if (pg < 1)
            //    pg = 1;

            //int recsCount = products.Count();

            //var pager = new Pager(recsCount, pg, pageSize);
            //int recSkip = (pg - 1) * pageSize;
            //var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
            //this.ViewBag.Pager = pager;
            //return View(data);
            return View(products);
        }
        public IActionResult ProductsByCategory(int id)
        {
            var products = ProductsServices.GetProductsByCategoryId(id);
            return View(products);
        }
    }
}
