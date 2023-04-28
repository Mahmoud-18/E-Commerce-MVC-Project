using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();        
        Brand GetById(int id);
        void Insert(Brand newBrand);
        void Update(int id, Brand brand);
        void Delete(int id);
    }
}
