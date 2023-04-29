using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Services
{
    public class ProductsServices
    {
        ICategoryRepository category;
        IProductRepository product;
        IProductCategoryRepository productCategory;

        public ProductsServices(ICategoryRepository _categoryRepository, IProductRepository _productRepository, IProductCategoryRepository _productCategory)
        {
            category = _categoryRepository;
            product = _productRepository;
            productCategory = _productCategory;
        }
        public List<ShoppingProductsViewModel> GetAllProducts()
        {
            List<ShoppingProductsViewModel> products = new();
            var allProducts = product.GetAll();
            foreach (Product pro in allProducts)
            {
                //var DiscId = context.Product.Where(d => d.Id == pro.Id).FirstOrDefault()!.DiscountId;
                //var DiscAmount = context.Discount.Where(d => d.Id == DiscId).FirstOrDefault()!.DiscountPercentage;
                //var price = context.ProductItem.Where(i => i.Id == pro.Id).FirstOrDefault()!.Price;

                products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
            }
            return (products);
        }
        //#region Female Products in Shop Page
        //public List<ShoppingProductsViewModel> GetFemaleProducts()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();
        //    var allWomenCategories = context.Category.Where(p => p.ParentCategoryId == 2).ToList();

        //    foreach (Category Cat in allWomenCategories)
        //    {
        //        var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == Cat.Id).ToList();
        //        if (categoryProducts == null)
        //        {
        //            continue;
        //        }
        //        foreach (var Product in categoryProducts)
        //        {
        //            Product pro = Product.Product;

        //            products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //        }
        //    }
        //    return (products);
        //}

        //public List<ShoppingProductsViewModel> GetFemaleDresses()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();
        //    var allWomenCategories = context.Category.Where(p => p.ParentCategoryId == 2).ToList();

        //    var dressCat = context.Category.FirstOrDefault(n => n.Name == "Dress");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == dressCat.Id);
        //    foreach (var Product in categoryProducts)
        //    {
        //        Product pro = Product.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //public List<ShoppingProductsViewModel> GetFemaleShirts()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();

        //    var shirtCat = context.Category.Where(i => i.ParentCategoryId == 2).FirstOrDefault(n => n.Name == "shirt");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == shirtCat.Id);
        //    foreach (var catProduct in categoryProducts)
        //    {
        //        Product pro = catProduct.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //public List<ShoppingProductsViewModel> GetFemaleTshirts()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();

        //    var tshirtCat = context.Category.Where(i => i.ParentCategoryId == 2).FirstOrDefault(n => n.Name == "T-shirt");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == tshirtCat.Id);
        //    foreach (ProductCategory catProduct in categoryProducts)
        //    {
        //        Product? pro = catProduct.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //public List<ShoppingProductsViewModel> GetFemaleJeans()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();

        //    var jeansCat = context.Category.Where(i => i.ParentCategoryId == 2).FirstOrDefault(n => n.Name == "Jeans");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == jeansCat.Id);
        //    foreach (ProductCategory catProduct in categoryProducts)
        //    {
        //        Product? pro = catProduct.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //#endregion

        //#region Male Products in Shop Page
        //public List<ShoppingProductsViewModel> GetMaleProducts()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();
        //    var allWomenCategories = context.Category.Where(p => p.ParentCategoryId == 1).ToList();

        //    foreach (Category Cat in allWomenCategories)
        //    {
        //        var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == Cat.Id).ToList();
        //        if (categoryProducts == null)
        //        {
        //            continue;
        //        }
        //        foreach (var Product in categoryProducts)
        //        {
        //            Product? pro = Product.Product;

        //            products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //        }
        //    }
        //    return (products);
        //}
        //public List<ShoppingProductsViewModel> GetMaleShirts()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();

        //    var shirtCat = context.Category.Where(i => i.ParentCategoryId == 1).FirstOrDefault(n => n.Name == "shirt");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == shirtCat.Id);
        //    foreach (var catProduct in categoryProducts)
        //    {
        //        Product? pro = catProduct.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //public List<ShoppingProductsViewModel> GetMaleTshirts()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();

        //    var tshirtCat = context.Category.Where(i => i.ParentCategoryId == 1).FirstOrDefault(n => n.Name == "T-shirt");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == tshirtCat.Id);
        //    foreach (var catProduct in categoryProducts)
        //    {
        //        Product? pro = catProduct.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //public List<ShoppingProductsViewModel> GetMaleJeans()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();

        //    var jeansCat = context.Category.Where(i => i.ParentCategoryId == 1).FirstOrDefault(n => n.Name == "Trousers");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == jeansCat.Id);
        //    foreach (var catProduct in categoryProducts)
        //    {
        //        Product? pro = catProduct.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //public List<ShoppingProductsViewModel> GetMaleSweatshirt()
        //{
        //    List<ShoppingProductsViewModel> products = new();
        //    var allProducts = context.Category.ToList();

        //    var jeansCat = context.Category.FirstOrDefault(n => n.Name == "SweatShrt");

        //    var categoryProducts = context.ProductCategory.Include("Product").Where(i => i.CategoryId == jeansCat.Id);
        //    foreach (var catProduct in categoryProducts)
        //    {
        //        Product? pro = catProduct.Product;

        //        products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name, Image = pro.Image });
        //    }
        //    return (products);
        //}
        //#endregion

        public List<ShoppingProductsViewModel> GetProductsByCategoryId(int id)
        {
            List<ShoppingProductsViewModel> products = new();
            Category? cat =  category.GetById(id);
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
