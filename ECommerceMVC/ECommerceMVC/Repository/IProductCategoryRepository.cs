using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetAll();
        ProductCategory GetById(int id);
        void Insert(ProductCategory productCategory);
        void Update(int id, ProductCategory productCategory);
        void Delete(int id);
    }
}
