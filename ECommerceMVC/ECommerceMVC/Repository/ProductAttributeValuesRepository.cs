using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class ProductAttributeValuesRepository : IProductAttributeValuesRepository
    {
        EcommerceDbContext context;

        public ProductAttributeValuesRepository(EcommerceDbContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            ProductAttributeValues productAttributeValues = GetById(id);
            context.ProductAttributeValues.Remove(productAttributeValues);
            context.SaveChanges();
        }

        public List<ProductAttributeValues> GetAll()
        {
            return context.ProductAttributeValues.ToList();
        }

        public ProductAttributeValues GetById(int id)
        {
            return context.ProductAttributeValues.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ProductAttributeValues productAttributeValues)
        {
            context.ProductAttributeValues.Add(productAttributeValues);
            context.SaveChanges();
        }

        public void Update(int id, ProductAttributeValues productAttributeValues)
        {
            context.Update(productAttributeValues);
            context.SaveChanges();
        }
    }
}
