using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();      
        Customer GetById(int id);
        void Insert(Customer newcustomer);
        void Update(int id, Customer customer);
        void Delete(int id);
        void SaveChanges();
    }
}
