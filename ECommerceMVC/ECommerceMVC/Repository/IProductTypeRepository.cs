using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductTypeRepository
    {
        List<ProductType> GetAll();
        ProductType GetById(int id);
        void Insert(ProductType productType);
        void Update(int id, ProductType productType);
        void Delete(int id);
    }
}
