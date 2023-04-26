using ECommerceMVC.Context;
using ECommerceMVC.Models;

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

    public Product GetById(int id)
    {
        return context.Product.FirstOrDefault(p => p.Id == id)!;
    }
}
