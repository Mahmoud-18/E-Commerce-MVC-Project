using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductItemRepository
    {
        List<ProductItem> GetAll();
        ProductItem GetById(int id);
        void Insert(ProductItem productItem);
        void Update(int id, ProductItem productItem);
        void Delete(int id);
    }
}
