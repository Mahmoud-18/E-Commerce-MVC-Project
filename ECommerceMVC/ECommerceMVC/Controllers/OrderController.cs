using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommerceMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IAddressRepository addressRepository;
        private readonly IPaymentMethodRepository paymentMethodRepository;
        private readonly IOrderStatusRepository orderStatusRepository;
        private readonly IOrderRepository orderRepository;
        private readonly UserManager<Customer> userManager;
        private readonly IShoppingBagRepository shoppingBagRepository;
        private readonly IShoppingBagItemRepository shoppingBagItemRepository;
        private readonly IProductRepository productRepository;
        private readonly IDiscountRepository discountRepository;

        public OrderController(IOrderRepository _orderRepository,IOrderItemRepository _orderItemRepository,
            IAddressRepository _addressRepository , IPaymentMethodRepository _paymentMethodRepository ,
            IOrderStatusRepository _orderStatusRepository, UserManager<Customer> _userManager,
            IShoppingBagRepository _shopBagRepository, IShoppingBagItemRepository _shopBagItemRepository,
            IProductRepository _productRepository, IDiscountRepository _discountRepository)
        {
            orderRepository = _orderRepository;
            orderItemRepository = _orderItemRepository;
            addressRepository = _addressRepository;
            paymentMethodRepository = _paymentMethodRepository;
            orderStatusRepository = _orderStatusRepository;
            userManager = _userManager;
            shoppingBagRepository = _shopBagRepository;
            shoppingBagItemRepository = _shopBagItemRepository;
            productRepository = _productRepository;
            discountRepository = _discountRepository;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<OrderDetails> orders = orderRepository.GetAll();
            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult OrderDetails()
        {
            OrderDetailsViewModel order = new OrderDetailsViewModel();
            return View(order);
        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        
        {
            Customer customer = await userManager.GetUserAsync(User);
            ShoppingBag bag = shoppingBagRepository.GetByCustomerId(customer.Id);
            CheckOutViewModel checkOutViewModel = new CheckOutViewModel();
            checkOutViewModel.Customer = customer;
            if (customer.ShippingAddressId > 0)
            {
                checkOutViewModel.ShippingAddress = addressRepository.GetById((int)customer.ShippingAddressId);
            }
            else
            {
                checkOutViewModel.ShippingAddress = addressRepository.GetAllByCustomerId(customer.Id).FirstOrDefault();
            }
            
            checkOutViewModel.Items = shoppingBagItemRepository.GetAllByBagId(bag.Id);
            if (checkOutViewModel.Items.Count > 0)
            {
                decimal sumafterdisc = 0;
                decimal sumbeforedisc = 0;
                foreach (var item in checkOutViewModel.Items)
                {
                    sumbeforedisc += (item.Quantity * item.ProductItem.Price);

                    var discount = productRepository.GetDiscountById(item.ProductItem.ProductId);
                    if (discount == null)
                    {
                        sumafterdisc += (item.Quantity * item.ProductItem.Price);
                    }
                    else
                    {
                        if (discountRepository.IsDiscountActive(discount.Id))
                        {
                            sumafterdisc += (item.Quantity * item.ProductItem.Price) - ((decimal)discount.DiscountPercentage * item.Quantity * item.ProductItem.Price);
                        }
                        else
                        {
                            sumafterdisc += (item.Quantity * item.ProductItem.Price);
                        }

                    }
                }
                checkOutViewModel.TotalPriceBeforeDiscount = sumbeforedisc;
                checkOutViewModel.TotalPriceAfterDiscount = sumafterdisc;
                checkOutViewModel.TotalDiscount = sumbeforedisc - sumafterdisc;
                checkOutViewModel.ShippingPrice = 40;
                checkOutViewModel.OrderTotalPrice = checkOutViewModel.TotalPriceAfterDiscount + checkOutViewModel.ShippingPrice;
                checkOutViewModel.PaymentMethod = paymentMethodRepository.GetAll();
                return View(checkOutViewModel);
            }
            else
            {
                ViewBag.Message = "add a product first";
                return RedirectToAction("Index","ShoppingBag");
            }
            
        }

        [Authorize]        
        public async Task<IActionResult> PlaceOrder(CheckOutViewModel checkOutViewModel)

        {
            Customer customer = await userManager.GetUserAsync(User);
            OrderDetails order = new OrderDetails();
            ShoppingBag bag = shoppingBagRepository.GetByCustomerId(customer.Id);
            List<ShoppingBagItem> items = shoppingBagItemRepository.GetAllByBagId(bag.Id);
            if (checkOutViewModel.PaymentMethodId == 1)
            {
                #region create order
                order.OrderDate = DateTime.Now;
                order.CreatedOnUtc = DateTime.UtcNow;
                OrderStatus orderStatus = orderStatusRepository.GetAll().FirstOrDefault(o => o.Status == "pending");               
                //order.OrderStatusId = 1;
                order.OrderStatusId = orderStatus.Id;
                if (customer.ShippingAddressId > 0)
                {
                    order.ShippingAddressId = addressRepository.GetById((int)customer.ShippingAddressId).Id;
                }
                else
                {
                   order.ShippingAddressId = addressRepository.GetAllByCustomerId(customer.Id).FirstOrDefault().Id;
                }                
                decimal sumafterdisc = 0;                
                foreach (var item in items)
                {                   
                    var discount = productRepository.GetDiscountById(item.ProductItem.ProductId);
                    if (discount == null)
                    {
                        sumafterdisc += (item.Quantity * item.ProductItem.Price);
                    }
                    else
                    {
                        if (discountRepository.IsDiscountActive(discount.Id))
                        {
                            sumafterdisc += (item.Quantity * item.ProductItem.Price) - ((decimal)discount.DiscountPercentage * item.Quantity * item.ProductItem.Price);
                        }
                        else
                        {
                            sumafterdisc += (item.Quantity * item.ProductItem.Price);
                        }

                    }
                }                                                                          
                order.CustomerId = customer.Id;
                order.PaymentMethodId = checkOutViewModel.PaymentMethodId;
               
                order.ShippingPrice = 40;
                order.OrderTotalPrice = sumafterdisc + order.ShippingPrice;

                orderRepository.Insert(order);

                #endregion

                #region create orderitems and decrease stock Quantity of product

                List<OrderItems> orderItems = new List<OrderItems>();
                List<ProductItem> productItems = new List<ProductItem>();

                foreach (var item in items)
                {
                    ProductItem productItem = new ProductItem();
                    productItem = item.ProductItem;
                    productItem.StockQuantity -= item.Quantity;
                    OrderItems orderItem = new OrderItems();
                    orderItem.ProductItemId = item.ProductItemId;
                    orderItem.Quantity = item.Quantity;
                    orderItem.Price = item.Quantity * item.ProductItem.Price;
                    orderItem.OrderDetailsId = order.Id;
                    orderItems.Add(orderItem);
                    productItems.Add(productItem);                    
                    shoppingBagItemRepository.Delete(item.Id);                    
                }
                orderItemRepository.InsertRange(orderItems);
                #endregion

                return View("AddOrderSuccess");
            }

                                                         
            return View("Checkout");
        }

    }

}
