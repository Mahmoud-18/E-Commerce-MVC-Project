using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using Microsoft.AspNetCore.Authorization;


namespace ECommerceMVC.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DiscountController : Controller
    {
   
        IDiscountRepository _Discount;
        public DiscountController(IDiscountRepository discount)
        {
            _Discount = discount;
        }
        public IActionResult Index()
        {
            var discount = _Discount.GetAll();
            return View(discount);
        }
        public IActionResult DiscountDetails(int id)
        {
            var discount = _Discount.GetById(id);
            return View(discount);
        }
        public IActionResult EditDiscount(int id)
        {
            var dis = _Discount.GetById(id);
            return View(dis);

        }
        [HttpPost]
        public async Task<IActionResult> EditDiscount([FromRoute] int id, Discount discount)
        {


            if (discount.DiscountPercentage != 0)

            {
                Discount old = _Discount.GetById(id);
                old.Name =discount.Name;
                old.DiscountPercentage=discount.DiscountPercentage;
                old.StartDate = discount.StartDate;
                old.EndDate = discount.EndDate;
                old.IsActice= discount.IsActice;
                
                _Discount.Update(id, old);
                return RedirectToAction("Index");
            }
            else
            {
                Discount bb = new Discount();
                bb.Id = id;
                bb.Name = discount.Name;
                bb.DiscountPercentage = discount.DiscountPercentage;
                bb.StartDate = discount.StartDate;
                bb.EndDate = discount.EndDate;
                bb.IsActice = discount.IsActice;
                return View(bb);
            }
        }
        public IActionResult AddDiscount()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddDiscount(Discount discount)
        {
            if (discount.DiscountPercentage != 0)
            {
              
                _Discount.Insert(discount);
                return RedirectToAction("Index");

            }
            else
            {
              
                return View("AddBrand", discount);
            }
        }


        public IActionResult Delete(int id)
        {

            _Discount.Delete(id);
            return NoContent();
        }
    }
}

