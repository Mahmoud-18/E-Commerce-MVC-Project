using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly EcommerceDbContext context;

        public CountryRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Country> GetAll()
        {
            throw new NotImplementedException();
        }

        public Country GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Country newcountry)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
