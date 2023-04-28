using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IDiscountRepository
    {
        List<Discount> GetAll();
        List<Discount> GetActiveDiscounts();
        Discount GetById(int id);
        void Insert(Country newDiscount);
        void Update(int id, Country discount);
        void Delete(int id);
    }
}
