using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductAttributeValuesRepository
    {
        List<ProductAttributeValues> GetAll();
        ProductAttributeValues GetById(int id);
        void Insert(ProductAttributeValues productAttributeValues);
        void Update(int id, ProductAttributeValues productAttributeValues);
        void Delete(int id);
    }
}
