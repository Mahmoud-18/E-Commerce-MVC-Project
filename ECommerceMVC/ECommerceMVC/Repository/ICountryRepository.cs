using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface ICountryRepository
    {
        List<Country> GetAll();        
        Country GetById(int id);
        void Insert(Country newcountry);
        void Update(int id, Country country);
        void Delete(int id);
    }
}
