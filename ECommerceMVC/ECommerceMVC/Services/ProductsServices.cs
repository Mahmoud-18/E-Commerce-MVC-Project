using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Services
{
    public class ProductsServices
    {
        ICategoryRepository category;
        IProductRepository product;
        IProductCategoryRepository productCategory;
        IDiscountRepository discountRepo;

        public ProductsServices(ICategoryRepository _categoryRepository,
            IProductRepository _productRepository, IProductCategoryRepository _productCategory,
            IDiscountRepository _discountRepository)
        {
            category = _categoryRepository;
            product = _productRepository;
            productCategory = _productCategory;
            discountRepo = _discountRepository;
        }
        public List<ShoppingProductsViewModel> GetAllProducts()
        {
            List<ShoppingProductsViewModel> products = new();
            var allProducts = product.GetAll();
            foreach (Product pro in allProducts)
            {

                var Discount = product.GetDiscountById(pro.Id);

                decimal? PriceBeforeDisc = pro.Price;

                if (pro.DiscountId != null)
                {
                    if (discountRepo.IsDiscountActive(Discount.Id))// Safwat : change ** pro.Discount.Id ** => ** (int)pro.DiscountId **
                    {
                        decimal priceAfterDiscount = pro.Price - (decimal)Discount.DiscountPercentage * pro.Price;
                        products.Add(new ShoppingProductsViewModel
                        {
                            Id = pro.Id,
                            Name = pro.Name,
                            Image = pro.Image,
                            PriceBeforeDisc = pro.Price,
                            PriceAfterDisc = priceAfterDiscount
                        });
                    }
                    else
                    {
                        products.Add(new ShoppingProductsViewModel
                        {
                            Id = pro.Id,
                            Name = pro.Name,
                            Image = pro.Image,
                            PriceBeforeDisc = pro.Price,
                        });
                    }
                    
                }
                else
                {
                    products.Add(new ShoppingProductsViewModel
                    {
                        Id = pro.Id,
                        Name = pro.Name,
                        Image = pro.Image,
                        PriceBeforeDisc = pro.Price,
                    });
                }
            }
            return (products);
        }

        public List<ShoppingProductsViewModel> GetProductsByCategoryId(int id)
        {
            List<ShoppingProductsViewModel> products = new();
            Category? cat = category.GetById(id);
            if (cat.ParentCategoryId != null)
            {
                var catProducts = productCategory.GetByCategoryId(id);
                foreach (var cProduct in catProducts)
                {
                    Product? pro = cProduct.Product;
                    var Discount = product.GetDiscountById(pro.Id);
                    decimal? PriceBeforeDisc = pro.Price;

                    if (pro.DiscountId != null)
                    {
                        if (discountRepo.IsDiscountActive((int)Discount.Id))
                        {
                            decimal priceAfterDiscount = pro.Price - (decimal)Discount.DiscountPercentage * pro.Price;
                            products.Add(new ShoppingProductsViewModel
                            {
                                Id = pro.Id,
                                Name = pro.Name,
                                Image = pro.Image,
                                PriceBeforeDisc = pro.Price,
                                PriceAfterDisc = priceAfterDiscount
                            });
                        }
                        else
                        {
                            products.Add(new ShoppingProductsViewModel
                            {
                                Id = pro.Id,
                                Name = pro.Name,
                                Image = pro.Image,
                                PriceBeforeDisc = pro.Price,
                            });
                        }
                    }
                    else
                    {
                        products.Add(new ShoppingProductsViewModel
                        {
                            Id = pro.Id,
                            Name = pro.Name,
                            Image = pro.Image,
                            PriceBeforeDisc = pro.Price,
                        });
                    }
                }
                return (products);
            }
            else
            {
                var cats = category.GetByParentCategoryId(id);
                foreach (Category c in cats)
                {
                    var catProducts = productCategory.GetByCategoryId(c.Id);
                    foreach (var cProduct in catProducts)
                    {
                        Product? pro = cProduct.Product;
                        decimal? PriceBeforeDisc = pro.Price;
                        var Discount = product.GetDiscountById(pro.Id);

                        if (pro.DiscountId != null)
                        {
                            if (discountRepo.IsDiscountActive((int)Discount.Id))
                            {
                                decimal priceAfterDiscount = pro.Price - (decimal)Discount.DiscountPercentage * pro.Price;
                                products.Add(new ShoppingProductsViewModel
                                {
                                    Id = pro.Id,
                                    Name = pro.Name,
                                    Image = pro.Image,
                                    PriceBeforeDisc = pro.Price,
                                    PriceAfterDisc = priceAfterDiscount
                                });
                            }
                            else
                            {
                                products.Add(new ShoppingProductsViewModel
                                {
                                    Id = pro.Id,
                                    Name = pro.Name,
                                    Image = pro.Image,
                                    PriceBeforeDisc = pro.Price,
                                });
                            }
                        }
                        else
                        {
                            products.Add(new ShoppingProductsViewModel
                            {
                                Id = pro.Id,
                                Name = pro.Name,
                                Image = pro.Image,
                                PriceBeforeDisc = pro.Price,
                            });
                        }
                    }
                }
                return (products);
            }
        }
    }
}
