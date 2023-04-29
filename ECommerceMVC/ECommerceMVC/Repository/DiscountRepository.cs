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
            context.Discount.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Discount> GetActiveDiscounts()
        {
            return context.Discount.Where(i => i.IsActice==true && DateTime.Now > i.StartDate && i.EndDate > DateTime.Now).ToList();
        }

        public List<Discount> GetAll()
        {
            return context.Discount.ToList();
        }

        public Discount GetById(int id)
        {
            return context.Discount.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Discount newDiscount)
        {
            context.Discount.Add(newDiscount);
            context.SaveChanges();
        }

        public void Update(int id, Discount discount)
        {
            context.Discount.Update(discount);
            context.SaveChanges();
        }
        public bool IsDiscountActive(int id)
        {
            var discount = GetById(id);
            if (discount.IsActice == true && DateTime.Now > discount.StartDate && discount.EndDate > DateTime.Now) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
