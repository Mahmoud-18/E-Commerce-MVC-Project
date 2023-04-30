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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        ICategoryRepository categoryRepository;
        IBrandRepository brandRepository;
        IDiscountRepository discountRepository;
        IProductAttributeRepository productAttributeRepository;
        IAttributeValuesRepository AttributeValuesRepository;
        IProductRepository productRepository;
        IProductItemRepository productItemRepository;
        IProductTypeRepository productTypeRepository;
        IProductImagesRepository productImagesRepository;
        IProductCategoryRepository productCategoryRepository;
        IProductTypeAttributeRepository productTypeAttributeRepository;
        IProductAttributeValuesRepository productAttributeValuesRepository;

        //
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        IAddressRepository addressRepo;
        IShoppingBagRepository shopBagRepository;
        ICountryRepository country;
        ICustomerRepository customer;

        public AdminController
            (UserManager<Customer> _userManager, SignInManager<Customer> _signInManager,
            IAddressRepository _addressRepository, IShoppingBagRepository shopBagRepository,
            ICountryRepository countryRepository, RoleManager<IdentityRole<int>> _roleManager,
            ICustomerRepository _customer, ICategoryRepository _categoryRepository, IBrandRepository _brandRepository,
            IDiscountRepository _discountRepository, IProductAttributeRepository _productAttributeRepository,
            IAttributeValuesRepository _AttributeValuesRepository, IProductRepository _productRepository,
            IProductItemRepository _productItemRepository, IProductTypeRepository _productTypeRepository,
            IProductImagesRepository _productImagesRepository, IProductCategoryRepository _productCategoryRepository,
            IProductTypeAttributeRepository _productTypeAttributeRepository, IProductAttributeValuesRepository _productAttributeValuesRepository)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            addressRepo = _addressRepository;
            this.shopBagRepository = shopBagRepository;
            country = countryRepository;
            roleManager = _roleManager;
            this.customer = _customer;
            //
            categoryRepository = _categoryRepository;
            brandRepository = _brandRepository;
            discountRepository = _discountRepository;
            productAttributeRepository = _productAttributeRepository;
            AttributeValuesRepository = _AttributeValuesRepository;
            productRepository = _productRepository;
            productItemRepository = _productItemRepository;
            productTypeRepository = _productTypeRepository;
            productImagesRepository = _productImagesRepository;
            productCategoryRepository = _productCategoryRepository;
            productTypeAttributeRepository = _productTypeAttributeRepository;
            productAttributeValuesRepository = _productAttributeValuesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            ViewData["CategoryList"] = categoryRepository.GetAll();
            ViewData["BrandList"] = brandRepository.GetAll();
            ViewData["DiscountList"] = discountRepository.GetAll();
            ViewData["ProductAttributes"] = productAttributeRepository.GetAll();
            ViewData["AttributeValues"] = AttributeValuesRepository.GetAll();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(AddProductViewModel addProductViewModel)
        {
            ViewData["CategoryList"] = categoryRepository.GetAll();
            ViewData["BrandList"] = brandRepository.GetAll();
            ViewData["DiscountList"] = discountRepository.GetAll();
            ViewData["ProductAttributes"] = productAttributeRepository.GetAll();
            ViewData["AttributeValues"] = AttributeValuesRepository.GetAll();

            if (!ModelState.IsValid)
            {
                return View(addProductViewModel);
            }
            // The Hell Start From Here ........

            #region Product Type
            //ProductType productType = new ProductType();
            //productType.Name = "Clothes";
            //productTypeRepository.Insert(productType);  

            #endregion

            #region Create Product
            Product product = new Product();
            product.Name = addProductViewModel.Name;
            product.Description = addProductViewModel.Description;
            product.Image = "/img/" + addProductViewModel.Images[0];
            product.CreatedAtUtc = DateTime.UtcNow;
            product.IsDeleted = false;
            product.DiscountId = addProductViewModel.DiscountId;
            product.Price = (decimal)addProductViewModel.Price;
            product.BrandId = addProductViewModel.BrandId;
            product.ProductTypeId = productTypeRepository.GetAll().FirstOrDefault(p => p.Name == "Clothes")!.Id;

            productRepository.Insert(product);

            #endregion

            #region Create Product Item
            int productId = product.Id ;
            foreach (var item in addProductViewModel.ProductAttribute)
            {
                ProductItem productItem = new ProductItem();
                
                productItem.Name = $"{product.Name}-{item.SizeAttributeValueID}-{item.ColorAttributeValueID}";
                // Create a random number form 0 to 1M
                int num;
                do
                {
                    Random random = new Random();
                    num = random.Next(1000000, 10000000);
                }
                while (!(productItemRepository.GetAll().Where(i => i.SKU == num).Count() == 0));
    

                productItem.SKU = num;
                productItem.StockQuantity = item.CountAttributeValue;
                productItem.ProductId = productId;
                productItem.Price = product.Price;
                productItem.CreatedAtUtc = DateTime.UtcNow;
                productItem.IsDeleted = false;
                productItemRepository.Insert(productItem); 
                
                var attributevalues = AttributeValuesRepository.GetAll().Where(i => i.Value == item.SizeAttributeValueID || i.Value == item.ColorAttributeValueID);
                foreach (var attribute in attributevalues)
                {
                    ProductAttributeValues productAttributeValues = new ProductAttributeValues();
                    productAttributeValues.ProductItemId = productItem.Id;
                    productAttributeValues.AttributeValuesId = attribute.Id;
                    productAttributeValuesRepository.Insert(productAttributeValues);
                }

            }
            #endregion

            #region Create Product Images
            List<ProductItem> productItemsListForImage = productItemRepository.GetAll().Where(p => p.ProductId == productId).ToList();
            foreach (var item_1 in productItemsListForImage)
            {
                foreach (var item in addProductViewModel.Images)
                {
                    ProductImages productImages = new ProductImages();
                    productImages.ImageURL = "/img/" +item;
                    productImages.ProductItemId = item_1.Id;
                    productImagesRepository.Insert(productImages);
                }
            }
            #endregion

            #region Create Product Category
            ProductCategory productCategory = new ProductCategory();
            productCategory.ProductId = productId;
            productCategory.CategoryId = addProductViewModel.CategoryId;
            productCategoryRepository.Insert(productCategory);
            #endregion

            #region Product Attribute
            //List<ProductAttribute> productAttribute = productAttributeRepository.GetAll().Where(p => p.Name == "Size" || p.Name == "Color").ToList();
            #endregion


            return View("AddProductSuccess");
        }
        public IActionResult gg()
        {

            return View("AddProductSuccess");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser([FromRoute] int id, EditUserViewModel updateduser)
        {
            if (ModelState.IsValid)
            {
                var user = customer.GetById(id);
                user.CountryId = updateduser.CountryId;
                user.DataOfBirth = updateduser.DataOfBirth;
                user.FirstName = updateduser.FirstName;
                user.LastName = updateduser.LastName;
                user.Gender = updateduser.Gender;
                user.IsActive = updateduser.IsActive;
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
                    if (await userManager.IsInRoleAsync(user, "Admin"))
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
        public async Task<IActionResult> EditRole(int id)
        {
            IdentityRole<int> role =await roleManager.FindByIdAsync(id.ToString());
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole([FromRoute] int id ,IdentityRole<int> role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole<int> updaterole = new();
                updaterole.Id = id;
                updaterole.Name=role.Name;
                updaterole.ConcurrencyStamp = role.ConcurrencyStamp;
                updaterole.NormalizedName = role.NormalizedName;
                customer.SaveChanges();
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
            }
            roleManager.DeleteAsync(role);
            return RedirectToAction("RolesIndex");
        }

        #endregion

        




    }
}

