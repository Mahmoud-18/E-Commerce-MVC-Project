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
        ICustomerRepository customer;

        public AdminController
            (UserManager<Customer> _userManager,SignInManager<Customer> _signInManager,
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

        public IActionResult Index()
        {
            return View();
        }

        #region Customer(Users) Controllers
        public IActionResult UsersIndex() 
        {
            var Users = customer.GetAll();            
            return View("UsersPage", Users);
        }
        public IActionResult AddUser()
        {
            RegisterViewModel register = new RegisterViewModel();           
            register.Countries = country.GetAll();
            register.Roles = roleManager.Roles.ToList();
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(RegisterViewModel newUser)
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
                    userModel.ShippingAddressId = address.Id;
                    addressRepo.Insert(address);
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

                    if (userModel.IsAdmin == true)
                    {
                       await userManager.AddToRoleAsync(userModel, "Admin");
                    }                                    
                    return RedirectToAction("UsersIndex", "Admin");
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

        public IActionResult UserDetails(int id)
        {
            var user = customer.GetById(id);
            return View(user);
        }
        public async Task<IActionResult> EditUser(int id)
        {
            var user = customer.GetById(id);           
            EditUserViewModel editUser = new EditUserViewModel();
            editUser.UserId = id;
            editUser.PhoneNumber = user.PhoneNumber;
            editUser.UserName = user.UserName;
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Gender = user.Gender;
            editUser.CountryId= user.CountryId;
            editUser.Countries= country.GetAll();
            editUser.Email = user.Email;
            editUser.IsActive = user.IsActive;
            editUser.IsAdmin = user.IsAdmin;
            editUser.IsDeleted = user.IsDeleted;
            editUser.DataOfBirth = user.DataOfBirth;
            editUser.Roles= roleManager.Roles.ToList();

            return View(editUser);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser([FromRoute] int id , EditUserViewModel updateduser)
        {
            if (ModelState.IsValid)
            {
                var user = customer.GetById(id);
                user.CountryId = updateduser.CountryId;
                user.DataOfBirth = updateduser.DataOfBirth;
                user.FirstName = updateduser.FirstName;
                user.LastName = updateduser.LastName;
                user.Gender = updateduser.Gender;
                user.IsActive= updateduser.IsActive;
                user.IsAdmin = updateduser.IsAdmin;
                user.PhoneNumber = updateduser.PhoneNumber;
                user.Email = updateduser.Email;
                user.UserName = updateduser.UserName;

                await userManager.UpdateAsync(user);

                if (user.IsAdmin == true)
                {
                    if (await userManager.IsInRoleAsync(user, "Admin") == false)
                    { 
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
                else
                {
                    if  (await userManager.IsInRoleAsync(user, "Admin"))
                    {
                        await userManager.RemoveFromRoleAsync(user, "Admin");
                    }
                }
                              
                
                return RedirectToAction("UsersIndex");
            }
            else
            {
                EditUserViewModel editUser = new EditUserViewModel();
                editUser.UserId = id;
                editUser.PhoneNumber = updateduser.PhoneNumber;
                editUser.UserName = updateduser.UserName;
                editUser.FirstName = updateduser.FirstName;
                editUser.LastName = updateduser.LastName;
                editUser.Gender = updateduser.Gender;
                editUser.CountryId = updateduser.CountryId;
                editUser.Countries = country.GetAll();
                editUser.Email = updateduser.Email;
                editUser.IsActive = updateduser.IsActive;
                editUser.IsAdmin = updateduser.IsAdmin;               
                editUser.DataOfBirth = updateduser.DataOfBirth;
                editUser.Roles = roleManager.Roles.ToList();
                return View(editUser);
            }
        }
        public IActionResult DeleteUser(int id)
        {
            var user = customer.GetById(id);                
            user.IsDeleted = true;
            user.DeleteDate = DateTime.UtcNow;
            customer.Update(id, user);
                      
            return RedirectToAction("UsersIndex");
        }

        #endregion

        #region Roles Controllers

        public IActionResult RolesIndex()
        {
            var Roles = roleManager.Roles.ToList();
            return View(Roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(IdentityRole<int> newrole)
        {
            if(ModelState.IsValid)
            {
                await roleManager.CreateAsync(newrole);
                return RedirectToAction("RolesIndex");
            }
            return View(newrole);
        }
        public IActionResult EditRole(int id)
        {
            var role = roleManager.FindByIdAsync(id.ToString());
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole([FromRoute] int id ,IdentityRole<int> role)
        {
            if (ModelState.IsValid)
            {
                await roleManager.UpdateAsync(role);
                return RedirectToAction("RolesIndex");
            }
            return View(role);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            List<Customer> users = (List<Customer>)await userManager.GetUsersInRoleAsync(role.Name);
            if (users.Count > 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    userManager.RemoveFromRoleAsync(users[i], role.Name);
                }

                roleManager.DeleteAsync(role);
            }
            return RedirectToAction("UsersIndex");
        }

        #endregion


    }
}
    
