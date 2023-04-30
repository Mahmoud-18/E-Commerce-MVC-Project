using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            List<OrderDetails> orders = orderRepository.GetAll();
            return View(orders);
        }
    }
}
