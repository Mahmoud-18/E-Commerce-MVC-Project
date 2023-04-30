using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Controllers
{
    public class ShoppingBagController : Controller
    {

        private readonly IShoppingBagItemRepository shoppingBagItemRepository;
        public ShoppingBagController(IShoppingBagItemRepository _shoppingBagItemRepository)
        {           
            shoppingBagItemRepository = _shoppingBagItemRepository;
        }

        public IActionResult Index()
        {
            ShoppingBagViewModel bagViewModel = new ShoppingBagViewModel();
            bagViewModel.Items = shoppingBagItemRepository.GetAll();
            decimal sum = 0;
            foreach (var item in bagViewModel.Items)
            {
                sum += (item.Quantity * item.ProductItem.Price);
            }
            bagViewModel.TotalPriceAfterDiscount = sum;
            bagViewModel.ShippingPrice = 10;
            bagViewModel.TotalPrice = bagViewModel.TotalPriceAfterDiscount + bagViewModel.ShippingPrice;

            return View(bagViewModel);
        }
    }
}