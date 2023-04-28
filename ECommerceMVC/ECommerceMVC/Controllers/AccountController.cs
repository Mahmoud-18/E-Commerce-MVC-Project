using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;
        IAddressRepository addressRepo;
        IShoppingBagRepository shopBagRepository;
        ICountryRepository country;
        public AccountController
            (UserManager<Customer> _userManager,
            SignInManager<Customer> _signInManager, IAddressRepository _addressRepository, IShoppingBagRepository shopBagRepository, ICountryRepository countryRepository)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            addressRepo = _addressRepository;
            this.shopBagRepository = shopBagRepository;
            country = countryRepository;
        }

        public IActionResult Register()
        {
            RegisterViewModel register = new RegisterViewModel();

            register.Countries =country.GetAll();
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
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

                    //await userManager.AddToRoleAsync(userModel, "Admin");

                    //------------------Create Cookie Authorization
                    await signInManager.SignInAsync(userModel, false);//create cookie //create cookie client
                    return RedirectToAction("Index", "Home");
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
            return View(newUser);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {               
                //Check Valid User ==>db
                Customer userModel =
                    await userManager.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found)
                    {
                        //cookie
                        await signInManager.SignInAsync(userModel, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "incorrect username or password");

            }
            return View(userVM);
        }

        //[HttpPost]
        //public JsonResult VerifyUsername(string username)
        //{
        //    bool isUsernameExists = _userService.IsUsernameExists(username);
        //    return Json(!isUsernameExists);
        //}

        //public JsonResult IsUserNameAvailable(string userName)
        //{
        //    var isAvailable = !context.Users.Any(u => u.UserName == userName);
        //    return Json(isAvailable, JsonRequestBehavior.AllowGet);
        //}

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
