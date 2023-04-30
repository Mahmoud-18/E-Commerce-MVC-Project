using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace ECommerceMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ICategoryRepository categoryRepository;
        IBrandRepository brandRepository;
        IDiscountRepository discountRepository;
        IProductAttributeRepository productAttributeRepository;
        IAttributeValuesRepository AttributeValuesRepository;
        public AdminController(ICategoryRepository _categoryRepository, IBrandRepository _brandRepository, IDiscountRepository _discountRepository, IProductAttributeRepository _productAttributeRepository, IAttributeValuesRepository _AttributeValuesRepository)
        {
            categoryRepository = _categoryRepository;
            brandRepository = _brandRepository;
            discountRepository = _discountRepository;
            productAttributeRepository = _productAttributeRepository;
            AttributeValuesRepository = _AttributeValuesRepository;
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
            return View();
        }

    }
}
