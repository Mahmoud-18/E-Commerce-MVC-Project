using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;
        EcommerceDbContext context;
        public ContactController
            (UserManager<Customer> _userManager,
            SignInManager<Customer> _signInManager, EcommerceDbContext context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            this.context = context;
        }      
        public IActionResult Index()
        {

            //Testtobedeleted testtobedeleted = new Testtobedeleted();
            //testtobedeleted.Seeding();
            return View();
        }


        [Authorize]
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  
            CustomerComplaint.CustomerId = Convert.ToInt32(userId);
            context.Complaint.Add(CustomerComplaint);
            context.SaveChanges();

            // TODO: Send email or save data to database

            TempData["Message"] = "Your message has been sent. Thank you!";
            return RedirectToAction("Index");
        }

    }
}



   