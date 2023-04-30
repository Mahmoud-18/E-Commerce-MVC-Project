using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
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
            return context.Users.Where(i => i.IsDeleted == false).ToList();
        }

        public Customer GetById(int id)
        {
            return context.Users.Include("Country").Where(i => i.IsDeleted == false).FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Customer newcustomer)
        {           
            context.Users.Add(newcustomer);
            context.SaveChanges();
        }

        public void Update(int id, Customer customer)
        {
            context.Users.Update(customer);
            context.SaveChanges();
        }
    }
}
