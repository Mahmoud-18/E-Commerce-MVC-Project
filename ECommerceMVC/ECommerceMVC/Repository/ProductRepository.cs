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
    public List<ProductItem> GetProductItemById(int id)
    {
        return context.ProductItem.Include(i=> i.ProductImages).Where(i => i.ProductId == id)!.ToList();
    }
    public Brand GetBrandById(int id)
    {
        return context.Brand.FirstOrDefault(b => b.Id == GetById(id).BrandId)!;
    }
    public List<string> GetImageById(int id)
    {
        ProductItem productItem = GetProductItemById(id)[0];
        if(productItem.ProductImages.Count == 0)
        {
            return null;
        }
        else
        {
             return context.ProductImages.Where(i => i.ProductItemId == productItem.Id).Select(i => i.ImageURL).ToList();
        }
    }
    public Discount GetDiscountById(int id)
    {
        return context.Discount.FirstOrDefault(d => d.Id == GetById(id).DiscountId)!;
    }
    // CURD Methods
    public void Delete(int id)
    {
        Product product = GetById(id);
        product.IsDeleted= true;
        context.SaveChanges();
    }
    public List<Product> GetAll()
    {
        return context.Product.Include(x=>x.ProductReviews).Include("Discount").Where(i=>i.IsDeleted == false).ToList();
    }

    public List<Product> GetAllInclude()
    {
        return context.Product.Include("Discount").Include(i=>i.Items).ThenInclude(u=>u.OrderItems).Include("Brand").Include("ProductType").Include("ProductCategories").Where(i => i.IsDeleted == false).ToList();
    }

    public Product GetById(int id)
    {
        return context.Product.FirstOrDefault(sh => sh.Id == id)!;
    }
    public Product GetByIdInclude(int id)
    {
        return context.Product.Include("Discount").Include(x => x.Items).ThenInclude(x => x.ProductAttributeValues).ThenInclude(x => x.AttributeValues).Include("Brand").Include("ProductType").FirstOrDefault(sh => sh.Id == id);
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
    public List<ProductIndexViewModel> GetAllViewModelProduct()
    {
        var all = context.Product.Include(p => p.Brand).Include(p=>p.ProductCategories).Where(i => i.IsDeleted == false).ToList();

        List<ProductIndexViewModel> productIndexViewModel = new List<ProductIndexViewModel>();
        foreach (var item in all)
        {
            productIndexViewModel.Add(new ProductIndexViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand!.Name,
                Price = (float)item.Price,
                CreatedAtUtc = item.CreatedAtUtc,
                Image = item.Image,
            });
        }
        return productIndexViewModel;
    }
}
