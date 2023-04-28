using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IShoppingBagRepository
    {
        List<ShoppingBagItem> GetAll();
        ShoppingBagItem GetById(int id);
        void Insert(ShoppingBagItem shoppingBag);
        void Update(int id, ShoppingBagItem shoppingBag);
        void Delete(int id);
    }
}
