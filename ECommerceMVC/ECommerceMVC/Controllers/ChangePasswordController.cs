using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ChangePasswordController : Controller
    {
      
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;
        
        ICustomerRepository customer;

        public ChangePasswordController
            (UserManager<Customer> _userManager, SignInManager<Customer> _signInManager,
            ICustomerRepository _customer)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            this.customer = _customer;
        }

            public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(EditPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("MyAccount", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


    }
}
