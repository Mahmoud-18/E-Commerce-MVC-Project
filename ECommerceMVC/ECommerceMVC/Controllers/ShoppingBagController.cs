using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public ShoppingBagController(IShoppingBagItemRepository _shoppingBagItemRepository, ICustomerRepository _customerRepository ,
            IShoppingBagRepository _shoppingBagRepository,IProductRepository _productRepository, IDiscountRepository _discountRepository)
        {           
            shoppingBagItemRepository = _shoppingBagItemRepository;
            customerRepository = _customerRepository;
            shoppingBagRepository = _shoppingBagRepository;
            productRepository = _productRepository;
            discountRepository = _discountRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            
            Customer customer = customerRepository.GetByUserName(User.Identity.Name);
            ShoppingBag bag = shoppingBagRepository.GetByCustomerId(customer.Id);
            ShoppingBagViewModel bagViewModel = new ShoppingBagViewModel();
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
    }
}