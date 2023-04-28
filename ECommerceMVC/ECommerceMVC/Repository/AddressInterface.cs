using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Repository
{
    public interface IAddressRepository
    {
        List<Address> GetAll();
        List<Address> GetAllByCustomerId(int id);
        Address GetById(int id);
        void Insert(Address newaddress);
        void Update(int id, Address address);
        void Delete(int id);

    }
}
