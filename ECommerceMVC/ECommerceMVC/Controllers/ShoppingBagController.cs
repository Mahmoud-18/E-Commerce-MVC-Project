using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Controllers
{
    public class ShoppingBagController : Controller
    {
        EcommerceDbContext Context = new EcommerceDbContext();
        public IActionResult Index()
        {
            ShoppingBagViewModel bagViewModel = new ShoppingBagViewModel();
            bagViewModel.Items = Context.ShoppingBagItem.Include("ProductItem").ToList();
            decimal sum = 0;
            foreach (var item in bagViewModel.Items)
            {
                sum += (item.Quantity * item.ProductItem.Price);
            }
            bagViewModel.SubTotal = sum;
            bagViewModel.ShippingPrice = 10;
            bagViewModel.Total = bagViewModel.SubTotal + bagViewModel.ShippingPrice;

            return View(bagViewModel);
        }
    }
}