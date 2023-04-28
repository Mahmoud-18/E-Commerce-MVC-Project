using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        EcommerceDbContext context;

        public ProductAttributeRepository(EcommerceDbContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            ProductAttribute productAttribute = GetById(id);
            context.ProductAttribute.Remove(productAttribute);
            context.SaveChanges();
        }

        public List<ProductAttribute> GetAll()
        {
            return context.ProductAttribute.ToList();
        }

        public ProductAttribute GetById(int id)
        {
            return context.ProductAttribute.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ProductAttribute productAttribute)
        {
            context.ProductAttribute.Add(productAttribute);
            context.SaveChanges();
        }

        public void Update(int id, ProductAttribute productAttribute)
        {
            context.Update(productAttribute);
            context.SaveChanges();
        }
    }
}
