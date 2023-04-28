using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductAttributeRepository
    {
        List<ProductAttribute> GetAll();
        ProductAttribute GetById(int id);
        void Insert(ProductAttribute productAttribute);
        void Update(int id, ProductAttribute productAttribute);
        void Delete(int id);
    }
}
