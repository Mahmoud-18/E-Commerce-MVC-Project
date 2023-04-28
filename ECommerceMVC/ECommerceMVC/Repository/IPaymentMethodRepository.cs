using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetAll();
        PaymentMethod GetById(int id);
        void Insert(PaymentMethod newPaymentMethod);
        void Update(int id, PaymentMethod paymentMethod);
        void Delete(int id);
    }
}
