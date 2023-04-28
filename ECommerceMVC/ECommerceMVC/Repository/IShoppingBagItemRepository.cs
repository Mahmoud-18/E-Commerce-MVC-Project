using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IShoppingBagItemRepository
    {
        List<ShoppingBagItem> GetAll();
        ShoppingBagItem GetById(int id);
        void Insert(ShoppingBagItem ShoppingBagItem);
        void Update(int id, ShoppingBagItem ShoppingBagItem);
        void Delete(int id);
    }
}
