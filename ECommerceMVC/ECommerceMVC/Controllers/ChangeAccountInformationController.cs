using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Win32;
using System.Data;
using System.Security.Claims;
using Microsoft.Build.Evaluation;
using System;

namespace ECommerceMVC.Controllers
{
        public class ChangeAccountInformationController : Controller
        {
            private readonly UserManager<Customer> userManager;
            private readonly SignInManager<Customer> signInManager;
            private readonly RoleManager<IdentityRole<int>> roleManager;
            IAddressRepository addressRepo;
            IShoppingBagRepository shopBagRepository;
            ICountryRepository country;
            ICustomerRepository customer;

            public ChangeAccountInformationController
                (UserManager<Customer> _userManager, SignInManager<Customer> _signInManager,
                IAddressRepository _addressRepository, IShoppingBagRepository shopBagRepository,
                ICountryRepository countryRepository, RoleManager<IdentityRole<int>> _roleManager,
                ICustomerRepository _customer)
            {
                userManager = _userManager;
                signInManager = _signInManager;
                addressRepo = _addressRepository;
                this.shopBagRepository = shopBagRepository;
                country = countryRepository;
                roleManager = _roleManager;
                this.customer = _customer;
            }


        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            EditUserViewModel editUser = new EditUserViewModel();
            editUser.UserId = user.Id;
            editUser.PhoneNumber = user.PhoneNumber;
            editUser.UserName = user.UserName;
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Gender = user.Gender;
            editUser.CountryId = user.CountryId;
            editUser.Countries = country.GetAll();
            editUser.Email = user.Email;
            editUser.DataOfBirth = user.DataOfBirth;
            return View(editUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update( EditUserViewModel updateduser)
        {
            var user = await userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                user.CountryId = updateduser.CountryId;
                user.DataOfBirth = updateduser.DataOfBirth;
                user.FirstName = updateduser.FirstName;
                user.LastName = updateduser.LastName;
                user.Gender = updateduser.Gender;
                user.PhoneNumber = updateduser.PhoneNumber;
                user.Email = updateduser.Email;
                user.UserName = updateduser.UserName;

                await userManager.UpdateAsync(user);

                return RedirectToAction("MyAccount", "Account");
            }
            else
            {
                EditUserViewModel editUser = new EditUserViewModel();
                editUser.UserId = user.Id;
                editUser.PhoneNumber = updateduser.PhoneNumber;
                editUser.UserName = updateduser.UserName;
                editUser.FirstName = updateduser.FirstName;
                editUser.LastName = updateduser.LastName;
                editUser.Gender = updateduser.Gender;
                editUser.CountryId = updateduser.CountryId;
                editUser.Countries = country.GetAll();
                editUser.Email = updateduser.Email;
                editUser.DataOfBirth = updateduser.DataOfBirth;
                return View(editUser);
            }
        }
        
    }
}
