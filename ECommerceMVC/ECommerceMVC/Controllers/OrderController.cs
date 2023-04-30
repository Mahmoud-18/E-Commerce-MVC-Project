using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public OrderController(IOrderRepository _orderRepository,IOrderItemRepository _orderItemRepository,
            IAddressRepository _addressRepository , IPaymentMethodRepository _paymentMethodRepository ,
            IOrderStatusRepository _orderStatusRepository)
        {
            orderRepository = _orderRepository;
            orderItemRepository = _orderItemRepository;
            addressRepository = _addressRepository;
            paymentMethodRepository = _paymentMethodRepository;
            orderStatusRepository = _orderStatusRepository;
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
        public IActionResult Checkout()
        {
            OrderDetailsViewModel order = new OrderDetailsViewModel();
            return View(order);
        }
    }

}
