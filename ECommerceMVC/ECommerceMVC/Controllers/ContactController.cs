using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ContactController : Controller
    {

        EcommerceDbContext context = new EcommerceDbContext();
        public IActionResult Index()
        {

            //Testtobedeleted testtobedeleted = new Testtobedeleted();
            //testtobedeleted.Seeding();
            return View();
        }



        [HttpPost]
        public IActionResult Submit(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            Complaint CustomerComplaint = new Complaint();
            CustomerComplaint.Name = model.Name;
            CustomerComplaint.Email = model.Email;
            CustomerComplaint.Subject = model.Subject;
            CustomerComplaint.Message = model.Message;

            context.Complaint.Add(CustomerComplaint);
            context.SaveChanges();

            // TODO: Send email or save data to database

            TempData["Message"] = "Your message has been sent. Thank you!";
            return RedirectToAction("Index");
        }

    }
}



   