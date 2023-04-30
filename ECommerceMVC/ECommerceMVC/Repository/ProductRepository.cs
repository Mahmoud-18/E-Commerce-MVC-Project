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
   
    // Repo
    public Product GetProductById(int id)
    {
        return context.Product.FirstOrDefault(p => p.Id == id)!;
    }
    public List<ProductItem> GetProductItemById(int id)
    {
        return context.ProductItem.Where(i => i.ProductId == id)!.ToList();
    }
    public Brand GetBrandById(int id)
    {
        return context.Brand.FirstOrDefault(b => b.Id == GetProductById(id).BrandId)!;
    }
    public List<string> GetImageById(int id)
    {
        ProductItem productItem = GetProductItemById(id)[0];
        return context.ProductImages.Where(i => i.ProductItemId == productItem.Id).Select(i => i.ImageURL).ToList();
    }
    public Discount GetDiscountById(int id)
    {
        return context.Discount.FirstOrDefault(d => d.Id == GetProductById(id).DiscountId)!;
    }
    // CURD Methods
    public void Delete(int id)
    {
        Product product = GetById(id);
        context.Product.Remove(product);
        context.SaveChanges();
    }

    public List<Product> GetAll()
    {
        return context.Product.ToList();
    }

    public Product GetById(int id)
    {
        return context.Product.FirstOrDefault(sh => sh.Id == id)!;
    }

    public void Insert(Product product)
    {
        context.Product.Add(product);
        context.SaveChanges();
    }

    public void Update(int id, Product product)
    {
        context.Update(product);
        context.SaveChanges();
    }
}
