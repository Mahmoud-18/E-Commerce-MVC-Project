using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductItemRepository
    {
        List<ProductItem> GetAll();
        ProductItem GetById(int id);      
        List<ProductItem> GetByProductId(int id);
        void Insert(ProductItem productItem);
        void InsertRange(List<ProductItem> productItems);
        void Update(int id, ProductItem productItem);
        void UpdateRange(List<ProductItem> productItems);
        void Delete(int id);
    }
}
