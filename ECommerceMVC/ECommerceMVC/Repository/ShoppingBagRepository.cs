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
        ShoppingBag shoppingBag = GetById(id);
        context.ShoppingBag.Remove(shoppingBag);
        context.SaveChanges();
    }

    public List<ShoppingBag> GetAll()
    {
        return context.ShoppingBag.ToList();
    }
    public ShoppingBag GetById(int id)
    {
        return context.ShoppingBag.FirstOrDefault(sh => sh.Id == id)!;
    }

    public ShoppingBag GetByCustomerId(int id)
    {
        return context.ShoppingBag.FirstOrDefault(sh => sh.CustomerId == id)!;
    }

    public void Insert(ShoppingBag shoppingBag)
    {
        context.ShoppingBag.Add(shoppingBag);
        context.SaveChanges();
    }
  

    public void Update(int id, ShoppingBag shoppingBag)
    {
        context.Update(shoppingBag);
        context.SaveChanges();
    }
}
