using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Repository;

public class ProductRepository : IProductRepository
{
    EcommerceDbContext context;

    public ProductRepository(EcommerceDbContext _context)
    {
        context = _context;
    }

    public List<Product> GetAll()
    {
        return context.Product.ToList();
    }

    public List<ShoppingProductsViewModel> GetAllProducts()
    {
        List<ShoppingProductsViewModel> products= new();
        foreach(Product pro in context.Product)
        {
            //var DiscId = context.Product.Where(d => d.Id == pro.Id).FirstOrDefault()!.DiscountId;
            //var DiscAmount = context.Discount.Where(d => d.Id == DiscId).FirstOrDefault()!.DiscountPercentage;
            var price = context.ProductItem.Where(i => i.Id == pro.Id).FirstOrDefault()!.Price;

            products.Add(new ShoppingProductsViewModel { Id = pro.Id, Name = pro.Name,Image = pro.Image});
        }
        return(products);
    }

    public Product GetById(int id)
    {
        return context.Product.FirstOrDefault(p => p.Id == id)!;
    }
}
