using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        EcommerceDbContext context;

        public ProductTypeRepository(EcommerceDbContext _context)
        {
            context = _context;
        }

        public void Delete(int id)
        {
            ProductType productType = GetById(id);
            context.ProductType.Remove(productType);
            context.SaveChanges();
        }

        public List<ProductType> GetAll()
        {
            return context.ProductType.ToList();
        }

        public ProductType GetById(int id)
        {
            return context.ProductType.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ProductType productType)
        {
            context.ProductType.Add(productType);
            context.SaveChanges();
        }

        public void Update(int id, ProductType productType)
        {
            context.Update(productType);
            context.SaveChanges();
        }
    }
}
