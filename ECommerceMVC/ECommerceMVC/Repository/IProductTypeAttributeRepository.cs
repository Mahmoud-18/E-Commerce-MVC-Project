using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductTypeAttributeRepository
    {
        List<ProductTypeAttribute> GetAll();
        ProductTypeAttribute GetById(int id);
        void Insert(ProductTypeAttribute productTypeAttribute);
        void Update(int id, ProductTypeAttribute productTypeAttribute);
        void Delete(int id);
    }
}
