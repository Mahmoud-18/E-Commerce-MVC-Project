using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IShoppingBagRepository
    {
        List<ShoppingBag> GetAll();
        ShoppingBag GetById(int id);
        void Insert(ShoppingBag shoppingBag);
        void Update(int id, ShoppingBag shoppingBag);
        void Delete(int id);
    }
}
