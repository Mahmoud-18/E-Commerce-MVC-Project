using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Controllers
{
    public class ShoppingBagController : Controller
    {

        private readonly IShoppingBagItemRepository shoppingBagItemRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IShoppingBagRepository shoppingBagRepository;
        private readonly IProductRepository productRepository;
        private readonly IDiscountRepository discountRepository;
        private readonly UserManager<Customer> userManager;

        public ShoppingBagController(IShoppingBagItemRepository _shoppingBagItemRepository, ICustomerRepository _customerRepository ,
            IShoppingBagRepository _shoppingBagRepository,IProductRepository _productRepository, IDiscountRepository _discountRepository,
            UserManager<Customer> _userManager)
        {           
            shoppingBagItemRepository = _shoppingBagItemRepository;
            customerRepository = _customerRepository;
            shoppingBagRepository = _shoppingBagRepository;
            productRepository = _productRepository;
            discountRepository = _discountRepository;
            userManager = _userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            Customer customer = await userManager.GetUserAsync(User);          
            ShoppingBag bag = shoppingBagRepository.GetByCustomerId(customer.Id);
            ShoppingBagViewModel bagViewModel = new ShoppingBagViewModel();
            bagViewModel.CustomerId = customer.Id;
            bagViewModel.Id = bag.Id;
            bagViewModel.Items = shoppingBagItemRepository.GetAllByBagId(bag.Id);
            decimal sumafterdisc = 0;
            decimal sumbeforedisc = 0;
            foreach (var item in bagViewModel.Items)
            {
                sumbeforedisc += (item.Quantity * item.ProductItem.Price);

                var discount = productRepository.GetDiscountById(item.ProductItem.ProductId);
                if (discount == null)
                {
                    sumafterdisc += (item.Quantity * item.ProductItem.Price);
                }
                else
                {
                    if ( discountRepository.IsDiscountActive(discount.Id))
                    {
                        sumafterdisc += (item.Quantity * item.ProductItem.Price) - ((decimal)discount.DiscountPercentage * item.Quantity * item.ProductItem.Price);
                    }
                    else
                    {
                        sumafterdisc += (item.Quantity * item.ProductItem.Price);
                    }
                   
                }
            }                   
            bagViewModel.TotalPriceBeforeDiscount = sumbeforedisc;           
            bagViewModel.TotalPriceAfterDiscount = sumafterdisc;
            bagViewModel.TotalDiscount = sumbeforedisc-sumafterdisc;              
            bagViewModel.ShippingPrice = 40;
            bagViewModel.TotalPrice = bagViewModel.TotalPriceAfterDiscount + bagViewModel.ShippingPrice;

            return View(bagViewModel);
        }
        public ActionResult RemoveFromBag(int id)
        {
            shoppingBagItemRepository.Delete(id);
            return RedirectToAction("Index", "ShoppingBag");
        }
    }
}