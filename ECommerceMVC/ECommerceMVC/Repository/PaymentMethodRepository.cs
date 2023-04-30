using ECommerceMVC.Context;
using ECommerceMVC.Models;
using System.Diagnostics.Metrics;

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
            PaymentMethod pm = GetById(id);
            pm.IsDeleted = true;
            pm.DeletedOnUtc = DateTime.UtcNow;
            _context.SaveChanges();
        }

        public List<PaymentMethod> GetAll()
        {
            return _context.PaymentMethod.Where(i => i.IsDeleted == false).ToList();
        }

        public PaymentMethod GetById(int id)
        {
            return _context.PaymentMethod.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(PaymentMethod newPaymentMethod)
        {
            _context.PaymentMethod.Add(newPaymentMethod);
            _context.SaveChanges();
        }

        public void Update(int id, PaymentMethod paymentMethod)
        {
            _context.Update(paymentMethod);
            _context.SaveChanges();
        }
    }
}
