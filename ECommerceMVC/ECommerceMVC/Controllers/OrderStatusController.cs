using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceMVC.Controllers
{
    [Authorize(Roles = "Admin")]

    public class OrderStatusController : Controller
    {
        IOrderStatusRepository _orderStatusRepository;
        public OrderStatusController(IOrderStatusRepository orders)
        {
            _orderStatusRepository = orders;
        }
        public IActionResult Index()
        {
            var ors = _orderStatusRepository.GetAll();
            return View(ors);
        }

        public IActionResult EditOrderStatus(int id)
        {
            var c = _orderStatusRepository.GetById(id);
            return View(c);

        }
        [HttpPost]
        public async Task<IActionResult> EditOrderStatus([FromRoute] int id, OrderStatus ors)
        {


            if (ors.Orders != null)

            {
                ors.UpdatedOnUtc= DateTime.UtcNow;
                _orderStatusRepository.Update(id, ors);
                return RedirectToAction("Index");
            }
            else
            {
          
                return View(ors);
            }
        }
        public IActionResult AddOrderStatus()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddOrderStatus(OrderStatus ors)
        {
            if (ors.Orders != null)

            {
                ors.CreatedOnUtc= DateTime.UtcNow;
                _orderStatusRepository.Insert( ors);
                return RedirectToAction("Index");
            }
            else
            {
       
                return View( ors);
            }
        }
        public IActionResult OrderStatusDetails(int id)
        {
            var brand = _orderStatusRepository.GetById(id);
            return View(brand);
        }

        public IActionResult Delete(int id)
        {

            _orderStatusRepository.Delete(id);
            return NoContent();
        }
    }
}

