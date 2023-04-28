using ECommerceMVC.Context;
using ECommerceMVC.Models;

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
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer newcustomer)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
