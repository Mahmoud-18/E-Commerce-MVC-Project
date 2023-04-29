using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class AddressRepository : IAddressRepository
    {
        EcommerceDbContext context;

        public AddressRepository(EcommerceDbContext _context)
        {
            context = _context;
        }

        public void Delete(int id)
        {
            context.Address.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<Address> GetAll()
        {
            return context.Address.ToList();
        }

        public List<Address> GetAllByCustomerId(int id)
        {
            return context.Address.Where(i => i.CustomerId == id).ToList();
        }

        public Address GetById(int id)
        {

            return context.Address.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Address newaddress)
        {
            context.Address.Add(newaddress);
            context.SaveChanges();
        }

        public void Update(int id, Address address)
        {
            context.Update(address);
            context.SaveChanges();
        }
    }
        
}
