using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class ProductController : Controller
{
    IProductRepository productRepository;
    IProductItemRepository productItemRepository;
    IProductImagesRepository productImagesRepository;
    IAttributeValuesRepository attributeValuesRepository;
    IProductAttributeValuesRepository productAttributeValuesRepository;
    IProductAttributeRepository productAttributeRepository;
    ICustomerRepository customerRepository;
    IShoppingBagRepository shoppingBagRepository;
    IDiscountRepository discountRepository;

    int Id { get; set; }
    public ProductController(IProductRepository _productRepository, IProductItemRepository _productItemRepository,
        IProductImagesRepository _productImagesRepository, IAttributeValuesRepository _attributeValuesRepository,
        IProductAttributeValuesRepository _productAttributeValuesRepository, IProductAttributeRepository _productAttributeRepository,
            ICustomerRepository _customerRepository, IShoppingBagRepository _shoppingBagRepository, IDiscountRepository _discountRepository)
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

            Product product = productRepository.GetProductById(id);
            List<ProductItem> productItemList = productRepository.GetProductItemById(id);
            Brand brand = productRepository.GetBrandById(id);
            List<string> productImages = productRepository.GetImageById(id);
            Discount discount = productRepository.GetDiscountById(id);
            //if (discountRepository.IsDiscountActive(discount.Id))
            //{
            //    productDetailsViewModel.PriceBeforeDiscount = (1 - discount.DiscountPercentage) * (float)product.Price;
            //}
            //else
            //{
            //    productDetailsViewModel.PriceBeforeDiscount = 0;
            //}
            //List<ProductImages> productImages = context.ProductImages.Where(im => im.ProductItemId == productItem.Id).ToList();

            productDetailsViewModel.Name = product.Name;
            productDetailsViewModel.price = (float)product.Price;
            productDetailsViewModel.Description = product.Description;
            int count = 0;
            foreach (var item in productItemList)
            {
                // Add Image
                List<ProductImages> productImages1 = productImagesRepository.GetAll().Where(i => i.ProductItemId == item.Id).ToList();
                if (count == 0)
                {
                    foreach (var item2 in productImages1)
                    {
                        productDetailsViewModel.Image!.Add(item2.ImageURL);
                    }
                    count++;
                }

                // Add Size And Color For the Product Item
                ProductAttributeValues productAttributeValues = productAttributeValuesRepository.GetAll().Where(p => p.ProductItemId == item.Id).FirstOrDefault()!;
                AttributeValues attributeValues = attributeValuesRepository.GetById(productAttributeValues.AttributeValuesId);

                int productAttributeSizeId = productAttributeRepository.GetAll().Where(p => p.Name == "Size").FirstOrDefault()!.Id;
                int productAttributeColorId = productAttributeRepository.GetAll().Where(p => p.Name == "Color").FirstOrDefault()!.Id;
                if (attributeValues.ProductAttributeId == productAttributeSizeId)
                {
                    productDetailsViewModel.Size!.Add(attributeValues.Value);
                }
                else if (attributeValues.ProductAttributeId == productAttributeColorId)
                {
                    if (!productDetailsViewModel.Color!.Contains(attributeValues.Value))
                    {
                        productDetailsViewModel.Color!.Add(attributeValues.Value);
                    }
                }
            }
            productDetailsViewModel.BrandName = brand.Name;

            return View("ProductDetails", productDetailsViewModel);
        }
    }
    [HttpPost]
    public IActionResult AddToCard(ProductDetailsViewModel productDetailsViewModel)
    {
        ShoppingBagItem shoppingBagItem = new ShoppingBagItem();

        Customer customer = customerRepository.GetByUserName(User.Identity!.Name!);
        ShoppingBag bag = shoppingBagRepository.GetByCustomerId(customer.Id);

        shoppingBagItem.ShoppingBagId = bag.Id;
        //shoppingBagItem.ProductItemId = 
        shoppingBagItem.Quantity = productDetailsViewModel.ProductCount;

        return View();
    }


}
