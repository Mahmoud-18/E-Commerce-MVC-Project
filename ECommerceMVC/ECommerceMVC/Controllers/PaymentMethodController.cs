using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommerceMVC.Controllers
{
    [Authorize(Roles = "Admin")]

    public class PaymentMethodController : Controller
    {
        IPaymentMethodRepository _PaymentMethod;
        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            _PaymentMethod = paymentMethodRepository;
        }
        public IActionResult Index()
        {
            var payment = _PaymentMethod.GetAll();
            return View(payment);
        }

        public IActionResult EditPaymentMethod(int id)
        {
            var c = _PaymentMethod.GetById(id);
            return View(c);

        }
        [HttpPost]
        public async Task<IActionResult> EditPaymentMethod([FromRoute] int id, PaymentMethod pm)
        {


            if (pm.Name != null)

            {
               pm.UpdatedOnUtc = DateTime.UtcNow;
                _PaymentMethod.Update(id, pm);
                return RedirectToAction("Index");
            }
            else
            {

                return View(pm);
            }
        }
        public IActionResult AddPaymentMethod()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddPaymentMethod(PaymentMethod pm)
        {
            if (pm.Name != null)
            {
                 pm.CreatedOnUtc= DateTime.UtcNow;
                _PaymentMethod.Insert(pm);
                return RedirectToAction("Index");

            }
            else
            {
            
                return View( pm);
            }
        }


        public IActionResult Delete(int id)
        {

            _PaymentMethod.Delete(id);
            return NoContent();
        }
    }
}

