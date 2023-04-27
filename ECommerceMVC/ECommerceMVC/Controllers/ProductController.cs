﻿using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class ProductController : Controller
{
    IProductRepository productRepository;
    int Id { get; set; }
    public ProductController(IProductRepository _productRepository)
    {
        productRepository = _productRepository;
    }

    public IActionResult ProductDetails(int id)
    {
        if (Id != 0)
        {
            Id = id;
        }
        if (id == 0)
        {
            return Redirect("http://localhost:5136/product/productdetails" + Id);
        }
        else
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel();

            Product product = productRepository.GetProductById(id);
            ProductItem productItem = productRepository.GetProductItemById(id);
            Brand brand = productRepository.GetBrandById(id);
            List<string> productImages = productRepository.GetImageById(id);
            //List<ProductImages> productImages = context.ProductImages.Where(im => im.ProductItemId == productItem.Id).ToList();

            productDetailsViewModel.Name = product.Name;
            productDetailsViewModel.price = (float)productItem.Price;
            productDetailsViewModel.Image = productImages;// productImages.Select(img => img.ImageURL).ToList();
            productDetailsViewModel.Description = product.Description;
            productDetailsViewModel.CreatetAtUtc = productItem.CreatedAtUtc;
            productDetailsViewModel.SUK = productItem.SKU;
            productDetailsViewModel.StockUnits = productItem.StockQuantity;
            productDetailsViewModel.BrandName = brand.Name;
            productDetailsViewModel.BrandImage = brand.Image;
            return View("ProductDetails", productDetailsViewModel);
        }
    }


}
