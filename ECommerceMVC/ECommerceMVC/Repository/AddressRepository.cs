using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

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
            Address address = GetById(id);
            address.IsDeleted = true;
            context.SaveChanges();
        }

        public List<Address> GetAll()
        {
            return context.Address.Where(i=>i.IsDeleted == false).ToList();
        }

        public List<Address> GetAllByCustomerId(int id)
        {
            return context.Address.Include(i => i.Country).Include(i=>i.Customer).Where(i => i.CustomerId == id && i.IsDeleted == false).ToList();
        }

        public Address GetById(int id)
        {

            return context.Address.Include(i=> i.Country).FirstOrDefault(i => i.Id == id);
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
