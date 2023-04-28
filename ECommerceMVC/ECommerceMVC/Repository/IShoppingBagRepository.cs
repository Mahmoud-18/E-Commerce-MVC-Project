using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IShoppingBagRepository
    {
        List<ShoppingBag> GetAll();
        ShoppingBag GetById(int id);
        void Insert(ShoppingBag ShoppingBag);
        void Update(int id, ShoppingBag ShoppingBag);
        void Delete(int id);
    }
}