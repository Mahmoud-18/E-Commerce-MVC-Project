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
    public class ContactManagerController : Controller
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
        IComplaintRepository complaintRepository;
        //
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        IAddressRepository addressRepo;
        IShoppingBagRepository shopBagRepository;
        ICountryRepository country;
        ICustomerRepository customer;

        public ContactManagerController
            (UserManager<Customer> _userManager, SignInManager<Customer> _signInManager,
            IAddressRepository _addressRepository, IShoppingBagRepository shopBagRepository,
            ICountryRepository countryRepository, RoleManager<IdentityRole<int>> _roleManager,
            ICustomerRepository _customer, ICategoryRepository _categoryRepository, IBrandRepository _brandRepository,
            IDiscountRepository _discountRepository, IProductAttributeRepository _productAttributeRepository,
            IAttributeValuesRepository _AttributeValuesRepository, IProductRepository _productRepository,
            IProductItemRepository _productItemRepository, IProductTypeRepository _productTypeRepository,
            IProductImagesRepository _productImagesRepository, IProductCategoryRepository _productCategoryRepository,
            IProductTypeAttributeRepository _productTypeAttributeRepository, IProductAttributeValuesRepository _productAttributeValuesRepository,
            IComplaintRepository _complaintRepository)
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
            complaintRepository = _complaintRepository;
        }


        public IActionResult Index()
        {
            return View("Index", complaintRepository.GetAll().ToList());
        }

        public IActionResult DeleteComplaint(int id)
        {
            var complaint = complaintRepository.GetById(id);
            complaint.IsDeleted = true;
            complaint.DeletedOnUtc = DateTime.Now;
            complaintRepository.Update(id, complaint);
            return RedirectToAction("Index");
        }


      

    }
}

