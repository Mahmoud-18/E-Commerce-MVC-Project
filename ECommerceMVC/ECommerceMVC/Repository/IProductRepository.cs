using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetProductById(int id);
        ProductItem GetProductItemById(int id);
        Brand GetBrandById(int id);
        List<ShoppingProductsViewModel> GetAllProducts();
    }
}
