using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly EcommerceDbContext context;

        public DiscountRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Discount> GetActiveDiscounts()
        {
            throw new NotImplementedException();
        }

        public List<Discount> GetAll()
        {
            throw new NotImplementedException();
        }

        public Discount GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Country newDiscount)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Country discount)
        {
            throw new NotImplementedException();
        }
    }
}
