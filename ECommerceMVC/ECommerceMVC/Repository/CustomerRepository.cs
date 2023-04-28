using ECommerceMVC.Context;
using ECommerceMVC.Models;
using System.Diagnostics.Metrics;

namespace ECommerceMVC.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceDbContext context;

        public CustomerRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Users.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return context.Users.ToList();
        }

        public Customer GetById(int id)
        {
            return context.Users.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Customer newcustomer)
        {           
            context.Users.Add(newcustomer);
            context.SaveChanges();
        }

        public void Update(int id, Customer customer)
        {
            context.Update(customer);
            context.SaveChanges();
        }
    }
}
