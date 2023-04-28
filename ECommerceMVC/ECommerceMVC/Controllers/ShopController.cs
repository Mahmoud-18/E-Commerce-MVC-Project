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
            //_productRepository= productRepository;
            ProductsServices = productsServices;
        }
        public IActionResult ShowAllProducts()
        {
            var products = ProductsServices.GetAllProducts();
            return View(products);
            //return PartialView("_ProductsPartial", products);
        }
        #region Female Products Actions
        public IActionResult GetFemaleProducts()
        {
            var femaleProducts = ProductsServices.GetFemaleProducts();
            return PartialView("_ProductsPartial", femaleProducts);
            //return View(femaleProducts);
        }
        public IActionResult GetFemaleDress()
        {
            var dresses = ProductsServices.GetFemaleDresses();
            return PartialView("_ProductsPartial", dresses);
            //return View("GetFemaleProducts",dresses);
        }
        public IActionResult GetFemaleShirts()
        {
            var shirts = ProductsServices.GetFemaleShirts();
            return PartialView("_ProductsPartial", shirts);

            //return View("GetFemaleProducts",shirts);
        }
        public IActionResult GetFemaleTshirts()
        {
            var tShirts = ProductsServices.GetFemaleTshirts();
            return PartialView("_ProductsPartial", tShirts);

            //return View("GetFemaleProducts", tShirts);
        }
        public IActionResult GetFemaleJeans()
        {
            var jeans = ProductsServices.GetFemaleJeans();
            return PartialView("_ProductsPartial", jeans);

            //return View("GetFemaleProducts", jeans);
        }
        #endregion

        #region Male Products Actions
        public IActionResult GetMaleProducts()
        {
            var maleProducts = ProductsServices.GetMaleProducts();
            return PartialView("_ProductsPartial", maleProducts);
            //return View(maleProducts);
        }
        public IActionResult GetMaleShirts()
        {
            var shirts = ProductsServices.GetMaleShirts();
            return PartialView("_ProductsPartial", shirts);
            //return View("GetMaleProducts", shirts);
        }
        public IActionResult GetMaleTshirts()
        {
            var tShirts = ProductsServices.GetMaleTshirts();
            return PartialView("_ProductsPartial", tShirts);
            //return View("GetMaleProducts", tShirts);
        }
        public IActionResult GetMaleJeans()
        {
            var jeans = ProductsServices.GetMaleJeans();
            return PartialView("_ProductsPartial", jeans);
            //return View("GetMaleProducts", jeans);
        }
        public IActionResult GetMaleSweatshirt()
        {
            var sweatshirt = ProductsServices.GetMaleSweatshirt();
            return PartialView("_ProductsPartial", sweatshirt);
            //return View("GetMaleProducts", sweatshirt);
        }
        public IActionResult ProductsByCategory(int id)
        {
            var products =ProductsServices.GetProductsByCategoryId(id);
            return View(products);
        }
        #endregion
    }
}
