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
    public class AccountController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        IAddressRepository addressRepo;
        IShoppingBagRepository shopBagRepository;
        ICountryRepository country;
        ICustomerRepository customer;
        IOrderRepository order;
        public AccountController
           (UserManager<Customer> _userManager, SignInManager<Customer> _signInManager,
           IAddressRepository _addressRepository, IShoppingBagRepository shopBagRepository,
           ICountryRepository countryRepository, RoleManager<IdentityRole<int>> _roleManager,
           ICustomerRepository _customer,IOrderRepository _order)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            addressRepo = _addressRepository;
            this.shopBagRepository = shopBagRepository;
            country = countryRepository;
            roleManager = _roleManager;
            this.customer = _customer;
            order = _order;
        }



        public IActionResult Register()
        {
            RegisterViewModel register = new RegisterViewModel();

            register.Countries =country.GetAll();
            return View(register);
        }

        public IActionResult MyAccount()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult>  MyOrders()
        {
            
            Customer customer = await userManager.GetUserAsync(User);
            var orders = order.GetAllByCustomerId(customer.Id);
            return View(orders);
        }
        public IActionResult YourAddresses()
        {
            return View();
        }


        // asp-route-username  this is the correct parameter otherwise it wouldn't work
        // or we can use the Async way --> the correct way and we can easily get the current user data
        //public IActionResult EditProfile(string username)
        //{
        //    var user = customer.GetByUserName(username);
        //    return View(user);
        //}


        // here httpost wouldnt work bcs you are not writing on the database any thing
        // this method was only made so we can display the data but in a EditProfileViewModel
        [Authorize]
        //[HttpPost]
        public async Task<IActionResult> EditProfile()
        {
            var Current_user = await userManager.GetUserAsync(User);

            EditProfileViewModel editUser = new EditProfileViewModel();

            editUser.UserName = Current_user.UserName;
            editUser.Email = Current_user.Email;

            editUser.FirstName = Current_user.FirstName;
            editUser.LastName = Current_user.LastName;

            editUser.PhoneNumber = Current_user.PhoneNumber;

            editUser.DataOfBirth = Current_user.DataOfBirth;
            editUser.Gender = Current_user.Gender;

            return View(editUser);
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
                    userModel.ShippingAddressId = address.Id;
                    shopBagRepository.Insert(shoppingBag);

                    // add Claims
                    //Claim fullnameClaim = new Claim("FullName", $"{userModel.FirstName} {userModel.LastName}");
                    //Claim firstNameClaim = new Claim("FirstName", $"{userModel.FirstName}");
                    //Claim emailClaim = new Claim(ClaimTypes.Email, userModel.Email, ClaimValueTypes.Email);
                    //Claim idClaim = new Claim("UserId", $"{userModel.Id}");
                    //claims.Add(fullnameClaim);
                    //claims.Add(firstNameClaim);
                    //claims.Add(emailClaim);
                    //claims.Add(idClaim);

                    //await userManager.AddClaimsAsync(userModel, claims);


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
                        if (userModel.IsActive)
                        {
                            //cookie
                            await signInManager.SignInAsync(userModel, userVM.RememberMe);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("key", "Account is Deactivated");
                        }
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



        /////////////////////////////////////////////////////////////////////////////////////


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitProfileModifications (EditProfileViewModel EPVM)
        {

            Customer userModel = await userManager.GetUserAsync(User);


            // Change Password only
            if (ModelState.IsValid)
            {
                
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, EPVM.OldPassword);
                    if (found)
                    {
                        if (ModelState.IsValid)
                        {
                            userModel.PasswordHash = EPVM.NewPassword;
                        }
                    }

                    ModelState.AddModelError("", "incorrect  password");

                }


                userModel.UserName = EPVM.UserName;
                userModel.Email = EPVM.Email;


                userModel.FirstName = EPVM.FirstName;
                userModel.LastName = EPVM.LastName;


                userModel.PhoneNumber = EPVM.PhoneNumber;
                userModel.DataOfBirth = EPVM.DataOfBirth;
                userModel.Gender = EPVM.Gender;


                await userManager.UpdateAsync(userModel);
            }


            return RedirectToAction("MyAccount");
        }


        public async Task<IActionResult> Privew(int id)
        {
            var user = customer.GetById(id);
            EditUserViewModel editUser = new EditUserViewModel();
            editUser.UserId = id;
            editUser.PhoneNumber = user.PhoneNumber;
            editUser.UserName = user.UserName;
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Gender = user.Gender;
            editUser.CountryId = user.CountryId;
            editUser.Countries = country.GetAll();
            editUser.Email = user.Email;
            editUser.IsActive = user.IsActive;
            editUser.IsAdmin = user.IsAdmin;
            editUser.IsDeleted = user.IsDeleted;
            editUser.DataOfBirth = user.DataOfBirth;
            editUser.Roles = roleManager.Roles.ToList();

            return View(editUser);
        }










    }
}
