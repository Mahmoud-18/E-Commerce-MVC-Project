using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
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
    IShoppingBagItemRepository shoppingBagItemRepository;
    UserManager<Customer> userManager;
    int Id { get; set; }
    public ProductController(IProductRepository _productRepository, IProductItemRepository _productItemRepository,
        IProductImagesRepository _productImagesRepository, IAttributeValuesRepository _attributeValuesRepository,
        IProductAttributeValuesRepository _productAttributeValuesRepository, IProductAttributeRepository _productAttributeRepository,
            ICustomerRepository _customerRepository, IShoppingBagRepository _shoppingBagRepository, 
            IDiscountRepository _discountRepository, IShoppingBagItemRepository _shoppingBagItemRepository, UserManager<Customer> _userManager
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
            //Brand brand = productRepository.GetBrandById(id);
            List<string> productImages = productRepository.GetImageById(id);
            Discount discount = productRepository.GetDiscountById(id);
            if (discount != null)
            {
                if (discountRepository.IsDiscountActive(discount.Id))
                {
                    productDetailsViewModel.PriceBeforeDiscount = (1 - discount.DiscountPercentage) * (float)product.Price;
                }
                else
                {
                    productDetailsViewModel.PriceBeforeDiscount = 0;
                }
            }
            else
            {
                productDetailsViewModel.PriceBeforeDiscount = 0;
            }
            //List<ProductImages> productImages = context.ProductImages.Where(im => im.ProductItemId == productItem.Id).ToList();

            productDetailsViewModel.Name = product.Name;
            productDetailsViewModel.price = (float)product.Price;
            productDetailsViewModel.Description = product.Description;
            int count = 0;
            List<string> attributesValuesList = new List<string>();
            List<string> colorList = new List<string>();
            List<string> sizeList = new List<string>();
            int productAttributeSizeId = productAttributeRepository.GetAll().Where(p => p.Name == "Size").FirstOrDefault()!.Id;
            int productAttributeColorId = productAttributeRepository.GetAll().Where(p => p.Name == "Color").FirstOrDefault()!.Id;
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
                List<ProductAttributeValues> productAttributeValues = productAttributeValuesRepository.GetAll().Where(p => p.ProductItemId == item.Id).ToList();
                foreach (var item2 in productAttributeValues)
                {
                    string attrubuteValue = attributeValuesRepository.GetById(item2.AttributeValuesId).Value;

                    AttributeValues attribute = attributeValuesRepository.GetAll().Where(at => at.Value == attrubuteValue).FirstOrDefault()!;
                    if (attribute.ProductAttributeId == productAttributeSizeId)
                    {
                        sizeList.Add(attribute.Value);
                    }
                    if (attribute.ProductAttributeId == productAttributeColorId)
                    {
                        colorList.Add(attribute.Value);
                    }
                }

            }

            //productDetailsViewModel.BrandName = brand.Name;

            productDetailsViewModel.Color = colorList.Distinct().ToList();
            productDetailsViewModel.Size = sizeList.Distinct().ToList();

            //productDetailsViewModel.BrandName = brand.Name;


            return View("ProductDetails", productDetailsViewModel);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddToCard(ProductDetailsViewModel productDetailsViewModel)
    {
        ShoppingBagItem shoppingBagItem = new ShoppingBagItem();

        Customer customer = await userManager.GetUserAsync(User);
        ShoppingBag bag = shoppingBagRepository.GetByCustomerId(customer.Id);
        shoppingBagItem.ShoppingBagId = bag.Id;

        shoppingBagItem.Quantity = productDetailsViewModel.ProductCount;

        // Get the Product Item Id From Size & Color
        int color_AttributeValue_Id = attributeValuesRepository.GetAll().FirstOrDefault(at => at.Value == productDetailsViewModel.ColorId)!.Id;
        int size_AttributeValue_Id = attributeValuesRepository.GetAll().FirstOrDefault(at => at.Value == productDetailsViewModel.SizeId)!.Id;
        List<ProductAttributeValues> productAttributeValuesListColor = productAttributeValuesRepository.GetAll().Where(d => d.AttributeValuesId == color_AttributeValue_Id).ToList();
        List<ProductAttributeValues> productAttributeValuesListSize = productAttributeValuesRepository.GetAll().Where(d => d.AttributeValuesId == size_AttributeValue_Id).ToList();
        foreach (var item in productAttributeValuesListColor)
        {
            foreach (var item2 in productAttributeValuesListColor)
            {
                if (item.ProductItemId == item2.ProductItemId)
                {

                    shoppingBagItem.ProductItemId = item.ProductItemId;
                }
            }

        }
        shoppingBagItemRepository.Insert(shoppingBagItem);


        return View("ProductDetails");
    }


}
