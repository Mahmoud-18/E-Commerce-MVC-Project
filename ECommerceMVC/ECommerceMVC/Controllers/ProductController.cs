﻿using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ECommerceMVC.Controllers;

public class ProductController : Controller
{
    IProductRepository productRepository;
    IProductItemRepository productItemRepository;
    IProductImagesRepository productImagesRepository;
    IAttributeValuesRepository attributeValuesRepository;
    IProductTypeAttributeRepository productTypeAttributeRepository;
    IProductAttributeValuesRepository productAttributeValuesRepository;
    IProductAttributeRepository productAttributeRepository;
    ICustomerRepository customerRepository;
    IShoppingBagRepository shoppingBagRepository;
    IDiscountRepository discountRepository;
    IShoppingBagItemRepository shoppingBagItemRepository;
    IProductReviewRepository productReviewRepository;
    UserManager<Customer> userManager;
    int Id { get; set; }
    public ProductController(IProductRepository _productRepository, IProductItemRepository _productItemRepository,
        IProductImagesRepository _productImagesRepository, IAttributeValuesRepository _attributeValuesRepository,
        IProductAttributeValuesRepository _productAttributeValuesRepository, IProductAttributeRepository _productAttributeRepository,
            ICustomerRepository _customerRepository, IShoppingBagRepository _shoppingBagRepository,
            IDiscountRepository _discountRepository, IShoppingBagItemRepository _shoppingBagItemRepository,
            UserManager<Customer> _userManager, IProductTypeAttributeRepository _productTypeAttributeRepository,
            IProductReviewRepository _productReviewRepository
        )
    {
        productRepository = _productRepository;
        productItemRepository = _productItemRepository;
        productImagesRepository = _productImagesRepository;
        attributeValuesRepository = _attributeValuesRepository;
        productAttributeValuesRepository = _productAttributeValuesRepository;
        productAttributeRepository = _productAttributeRepository;
        customerRepository = _customerRepository;
        shoppingBagRepository = _shoppingBagRepository;
        discountRepository = _discountRepository;
        shoppingBagItemRepository = _shoppingBagItemRepository;
        userManager = _userManager;
        productTypeAttributeRepository = _productTypeAttributeRepository;
        productReviewRepository = _productReviewRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetails(int id)
    {
        if (Id != 0)
        {
            Id = id;
        }
        if (id == 0)
        {
            return Redirect("/Product/ProductDetails" + Id);
        }
        else
        {
            ProductDetailsViewModel productDetailsViewModel = new();

            Product product = productRepository.GetByIdInclude(id);

            List<ProductTypeAttribute> producttypeAttributes = productTypeAttributeRepository.GetByProductTypeId((int)product.ProductTypeId);

            List<ProductAttribute> variationswithoptions = new List<ProductAttribute>();

            int i = 0;
            foreach (var producttypeattribute in producttypeAttributes)
            {
                variationswithoptions.Add(productAttributeRepository.GetById(producttypeattribute.ProductAttributeId));
                foreach (var item in product.Items)
                {
                    foreach (var attribute in item.ProductAttributeValues)
                    {
                        if (attribute.AttributeValues.ProductAttributeId == variationswithoptions[i].Id)
                        {
                            if ((variationswithoptions[i].AttributeValues.Contains(attribute.AttributeValues)) == false)
                            {
                                variationswithoptions[i].AttributeValues.Add(attribute.AttributeValues);
                            }
                        }
                    }
                }
                i++;
            }

            productDetailsViewModel.Id = product.Id;
            productDetailsViewModel.Name = product.Name;
            productDetailsViewModel.price = (float)product.Price;
            productDetailsViewModel.Description = product.Description;
            productDetailsViewModel.BrandName = product.Brand.Name;
            productDetailsViewModel.Image = productRepository.GetImageById(id);
            productDetailsViewModel.variationswithoptions = variationswithoptions;
            productDetailsViewModel.Product = productRepository.GetById(id);

            ViewData.Add("Review", productReviewRepository.GetById(id));

            return View("ProductDetails", productDetailsViewModel);
        }
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddToCard(int id, ProductDetailsViewModel productDetailsViewModel)
    {
        ShoppingBagItem shoppingBagItem = new ShoppingBagItem();

        Customer customer = await userManager.GetUserAsync(User);
        ShoppingBag bag = shoppingBagRepository.GetByCustomerId(customer.Id);
        shoppingBagItem.ShoppingBagId = bag.Id;

        shoppingBagItem.Quantity = productDetailsViewModel.ProductCount;
        ProductItem productitem = productItemRepository.GetByProductId(id).Where(i => i.ProductAttributeValues.All(pa => productDetailsViewModel.AttributeValuesIds.Contains(pa.AttributeValuesId))).FirstOrDefault();
        shoppingBagItem.ProductItemId = productitem.Id;
        shoppingBagItem.ProductItem = productitem;
        if (shoppingBagItem.Quantity <= shoppingBagItem.ProductItem.StockQuantity)
        {
            shoppingBagItemRepository.Insert(shoppingBagItem);
            return RedirectToAction("Index", "ShoppingBag");
        }
        else
        {
            ProductDetailsViewModel productDetailsView = new ProductDetailsViewModel();
            ViewBag.Message = "No Enough Stock!";

            Product product = productRepository.GetByIdInclude(id);

            List<ProductTypeAttribute> producttypeAttributes = productTypeAttributeRepository.GetByProductTypeId((int)product.ProductTypeId);

            List<ProductAttribute> variationswithoptions = new List<ProductAttribute>();

            int i = 0;
            foreach (var producttypeattribute in producttypeAttributes)
            {
                variationswithoptions.Add(productAttributeRepository.GetById(producttypeattribute.ProductAttributeId));
                foreach (var item in product.Items)
                {
                    foreach (var attribute in item.ProductAttributeValues)
                    {
                        if (attribute.AttributeValues.ProductAttributeId == variationswithoptions[i].Id)
                        {
                            if ((variationswithoptions[i].AttributeValues.Contains(attribute.AttributeValues)) == false)
                            {
                                variationswithoptions[i].AttributeValues.Add(attribute.AttributeValues);
                            }
                        }
                    }
                }
                i++;
            }

            //shoppingBagItemRepository.Insert(shoppingBagItem);

            //return RedirectToAction("Index", "ShoppingBag");
            productDetailsViewModel.Id = product.Id;
            productDetailsViewModel.Name = product.Name;
            productDetailsViewModel.price = (float)product.Price;
            productDetailsViewModel.Description = product.Description;
            productDetailsViewModel.BrandName = product.Brand.Name;
            productDetailsViewModel.Image = productRepository.GetImageById(id);
            productDetailsViewModel.variationswithoptions = variationswithoptions;
            productDetailsViewModel.Product = productRepository.GetById(id);

            return View("ProductDetails", productDetailsViewModel);

        }
    }


    public IActionResult Review(ReviewViewModel reviewViewModel)
    {
        ProductReview productReview = new ProductReview();
        productReview.Name = reviewViewModel.Name;
        productReview.ProductId = reviewViewModel.ProductId;
        productReview.Description = reviewViewModel.ReviewDescription;
        productReview.Rate = reviewViewModel.Rate;
        productReview.CreatedDate = DateTime.UtcNow;
        productReviewRepository.Insert(productReview);
        return Redirect("/Product/ProductDetails/" + reviewViewModel.ProductId);


    }
}

