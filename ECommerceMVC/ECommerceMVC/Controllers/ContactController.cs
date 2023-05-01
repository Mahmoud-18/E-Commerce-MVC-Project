using Castle.Core.Resource;
using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceMVC.Controllers
{
    public class ContactController : Controller
    {
        
        //


        private readonly UserManager<Customer> userManager;
        ICustomerRepository customer;
        IComplaintRepository complaintRepository;
        public ContactController
           (ICustomerRepository _customer, IComplaintRepository _complaintRepository, UserManager<Customer> _userManager)
        {
            customer = _customer;
            complaintRepository = _complaintRepository;
            this.userManager = userManager;
            userManager = _userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Submit(ContactViewModel model)
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


            var user = await userManager.GetUserAsync(User);
            
            CustomerComplaint.CustomerId = user.Id;

            complaintRepository.Insert(CustomerComplaint);

            return RedirectToAction("Index", "Home");
        }


        //    [Authorize]
        //    [HttpPost]
        //    public IActionResult Submit(ContactViewModel model, string username)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View("Index", model);
        //        }
        //        Complaint CustomerComplaint = new Complaint();
        //        CustomerComplaint.Name = model.Name;
        //        CustomerComplaint.Email = model.Email;
        //        CustomerComplaint.Subject = model.Subject;
        //        CustomerComplaint.Message = model.Message;



        //        user = TempData["user"] as Customer;
        //        CustomerComplaint.CustomerId = user.Id;

        //        complaintRepository.Insert(CustomerComplaint);

        //        return RedirectToAction("Index", "Home");
        //    }
        }
    }



   