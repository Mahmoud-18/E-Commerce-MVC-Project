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
        
        return context.Product.Include("Discount").ToList();
    }
   
    // Repo
    public Product GetProductById(int id)
    {
        return context.Product.FirstOrDefault(p => p.Id == id)!;
    }
    public ProductItem GetProductItemById(int id)
    {
        return context.ProductItem.FirstOrDefault(i => i.ProductId == id)!;
    }
    public Brand GetBrandById(int id)
    {
        return context.Brand.FirstOrDefault(b => b.Id == GetProductById(id).BrandId)!;
    }
    public List<string> GetImageById(int id)
    {
        ProductItem productItem = GetProductItemById(id);
        return context.ProductImages.Where(i => i.ProductItemId == productItem.Id).Select(i => i.ImageURL).ToList();
    }
    public Discount GetDiscountById(int id)
    {
        return context.Discount.FirstOrDefault(d => d.Id == GetProductById(id).DiscountId)!;
    }
}
