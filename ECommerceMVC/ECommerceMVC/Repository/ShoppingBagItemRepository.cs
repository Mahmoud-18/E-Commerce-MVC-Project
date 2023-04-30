using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Repository
{
    public class ShoppingBagItemRepository : IShoppingBagItemRepository
    {

        EcommerceDbContext context;

        public ShoppingBagItemRepository(EcommerceDbContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            ShoppingBagItem shoppingBagItem = GetById(id);
            context.ShoppingBagItem.Remove(shoppingBagItem);
            context.SaveChanges();
        }

        public List<ShoppingBagItem> GetAll()
        {
            return context.ShoppingBagItem.Include("ProductItem").ToList();
        }
        public List<ShoppingBagItem> GetAllByBagId(int id)
        {
            return context.ShoppingBagItem.Include("ProductItem").Where(i=> i.ShoppingBagId == id).ToList();
        }
        public ShoppingBagItem GetById(int id)
        {
            return context.ShoppingBagItem.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ShoppingBagItem shoppingBagItem)
        {
            context.ShoppingBagItem.Add(shoppingBagItem);
            context.SaveChanges();
        }

        public void Update(int id, ShoppingBagItem shoppingBagItem)
        {
            context.Update(shoppingBagItem);
            context.SaveChanges();
        }
    }
}
