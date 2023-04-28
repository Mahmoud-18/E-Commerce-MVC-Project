using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        EcommerceDbContext _context;
        public PaymentMethodRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PaymentMethod> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaymentMethod GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PaymentMethod newPaymentMethod)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }
    }
}
