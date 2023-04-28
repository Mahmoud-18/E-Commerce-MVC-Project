using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository;

public class ShoppingBagRepository : IShoppingBagRepository
{
    EcommerceDbContext context;

    public ShoppingBagRepository(EcommerceDbContext _context)
    {
        context = _context;
    }

    public void Delete(int id)
    {
        ShoppingBagItem shoppingBag = GetById(id);
        context.ShoppingBag.Remove(shoppingBag);
        context.SaveChanges();
    }

    public List<ShoppingBagItem> GetAll()
    {
        return context.ShoppingBag.ToList();
    }

    public ShoppingBagItem GetById(int id)
    {
        return context.ShoppingBag.FirstOrDefault(sh => sh.Id == id)!;
    }

    public void Insert(ShoppingBagItem shoppingBag)
    {
        context.ShoppingBag.Add(shoppingBag);
        context.SaveChanges();
    }

    public void Update(int id, ShoppingBagItem shoppingBag)
    {
        context.Update(shoppingBag);
        context.SaveChanges();
    }
}
