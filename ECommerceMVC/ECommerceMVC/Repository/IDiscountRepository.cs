using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IDiscountRepository
    {
        List<Discount> GetAll();
        List<Discount> GetActiveDiscounts();
        Discount GetById(int id);
        void Insert(Discount newDiscount);
        void Update(int id, Discount discount);
        void Delete(int id);
    }
}
