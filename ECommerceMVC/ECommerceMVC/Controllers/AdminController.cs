using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Data;
using System.Security.Claims;

namespace ECommerceMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;        
        IAddressRepository addressRepo;
        IShoppingBagRepository shopBagRepository;
        ICountryRepository country;

        public AdminController
            (UserManager<Customer> _userManager,SignInManager<Customer> _signInManager,
            IAddressRepository _addressRepository, IShoppingBagRepository shopBagRepository,
            ICountryRepository countryRepository, RoleManager<IdentityRole<int>> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            addressRepo = _addressRepository;
            this.shopBagRepository = shopBagRepository;
            country = countryRepository;
            roleManager = _roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Customer(Users) Controllers
        public IActionResult CustomerIndex() 
        {
            var Users = userManager.Users.ToList();            
            return View("UsersPage", Users);
        }
        public IActionResult AddCustomer()
        {
            RegisterViewModel register = new RegisterViewModel();           
            register.Countries = country.GetAll();
            register.Roles = roleManager.Roles.ToList();
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomer(RegisterViewModel newUser)
        {
            List<Claim> claims = new List<Claim>();
            if (ModelState.IsValid)
            {               
                Customer userModel = new Customer();
                Address address = new Address();
                ShoppingBag shoppingBag = new ShoppingBag();
                userModel.UserName = newUser.UserName;
                userModel.PasswordHash = newUser.Password;
                userModel.Email = newUser.Email;
                userModel.Gender = newUser.Gender;
                userModel.PhoneNumber = newUser.PhoneNumber;
                userModel.LastName = newUser.LastName;
                userModel.FirstName = newUser.FirstName;
                userModel.CountryId = newUser.CountryId;
                userModel.CreatedOnUtc = DateTime.UtcNow;
                userModel.DataOfBirth = newUser.DataOfBirth;
                address.Address1 = newUser.Address;
                address.CreatedOnUtc = DateTime.UtcNow;
                address.City = newUser.City;
                address.State = newUser.State;
                address.CountryId = newUser.CountryId;
                userModel.IsAdmin = newUser.IsAdmin;

                //save db
                IdentityResult result =
                    await userManager.CreateAsync(userModel, newUser.Password);   //Block create user in db

                if (result.Succeeded)
                {
                    shoppingBag.CustomerId = userModel.Id;
                    address.CustomerId = userModel.Id;
                    addressRepo.Insert(address);
                    shopBagRepository.Insert(shoppingBag);

                    // add Claims
                    Claim fullnameClaim = new Claim("FullName", $"{userModel.FirstName} {userModel.LastName}");
                    Claim firstNameClaim = new Claim("FirstName", $"{userModel.FirstName}");
                    Claim emailClaim = new Claim(ClaimTypes.Email, userModel.Email, ClaimValueTypes.Email);
                    Claim idClaim = new Claim("UserId", $"{userModel.Id}");
                    claims.Add(fullnameClaim);
                    claims.Add(firstNameClaim);
                    claims.Add(emailClaim);
                    claims.Add(idClaim);

                    await userManager.AddClaimsAsync(userModel, claims);

                    if (userModel.IsAdmin == true)
                    {
                       await userManager.AddToRoleAsync(userModel, "Admin");
                    }
                    //------------------Create Cookie Authorization
                    await signInManager.SignInAsync(userModel, false);//create cookie //create cookie client
                    return RedirectToAction("CustomerIndex", "Admin");
                }
                //else
                //{
                //    foreach (var item in result.Errors)
                //    {
                //        ModelState.AddModelError("", item.Description);
                //    }
                //}
            }
            newUser.Countries = country.GetAll();
            newUser.Roles = roleManager.Roles.ToList();
            return View(newUser);
        }
        #endregion

    }
}
    
