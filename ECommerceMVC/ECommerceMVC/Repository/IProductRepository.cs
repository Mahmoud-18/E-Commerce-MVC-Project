using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Repository
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        public List<ProductItem> GetProductItemById(int id);
        Brand GetBrandById(int id);
        List<string> GetImageById(int id);
        Discount GetDiscountById(int id);
        public void Delete(int id);
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Insert(Product product);
        public void Update(int id, Product product);
    }
}
