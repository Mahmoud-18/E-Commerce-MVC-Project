using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ECommerceMVC.Repository
{
    public class ProductItemRepository : IProductItemRepository
    {
        EcommerceDbContext context;

        public ProductItemRepository(EcommerceDbContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            ProductItem productItem = GetById(id);
            context.ProductItem.Remove(productItem);
            context.SaveChanges();
        }

        public List<ProductItem> GetAll()
        {
            return context.ProductItem.ToList();
        }
        public List<ProductItem> GetByProductId(int id)
        {
            return context.ProductItem.Include(x=> x.ProductAttributeValues).ThenInclude(x => x.AttributeValues).Where(x => x.ProductId == id).ToList();
        }

        public ProductItem GetById(int id)
        {
            return context.ProductItem.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ProductItem productItem)
        {
            context.ProductItem.Add(productItem);
            context.SaveChanges();
        }

        public void Update(int id, ProductItem productItem)
        {
            context.Update(productItem);
            context.SaveChanges();
        }
    }
}
