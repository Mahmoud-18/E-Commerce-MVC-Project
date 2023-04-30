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
                products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
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

                    products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
                }
                return (products);
            }
            else
            {
                var cats = category.GetByParentCategoryId(id);
                foreach (Category c in cats)
                {
                    var catProducts = productCategory.GetByCategoryId(id);
                    foreach (var cProduct in catProducts)
                    {
                        Product? pro = cProduct.Product;

                        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
                    }
                }
                return (products);
            }
        }
    }
}
