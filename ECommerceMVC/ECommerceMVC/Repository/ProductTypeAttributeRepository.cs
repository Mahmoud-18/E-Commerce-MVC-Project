using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class ProductTypeAttributeRepository : IProductTypeAttributeRepository
    {
        EcommerceDbContext context;

        public ProductTypeAttributeRepository(EcommerceDbContext _context)
        {
            context = _context;
        }

        public void Delete(int id)
        {
            ProductTypeAttribute productTypeAttribute = GetById(id);
            context.ProductTypeAttribute.Remove(productTypeAttribute);
            context.SaveChanges();
        }

        public List<ProductTypeAttribute> GetAll()
        {
            return context.ProductTypeAttribute.ToList();
        }

        public ProductTypeAttribute GetById(int id)
        {
            return context.ProductTypeAttribute.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ProductTypeAttribute productTypeAttribute)
        {
            context.ProductTypeAttribute.Add(productTypeAttribute);
            context.SaveChanges();
        }

        public void Update(int id, ProductTypeAttribute productTypeAttribute)
        {
            context.Update(productTypeAttribute);
            context.SaveChanges();
        }
    }
}
