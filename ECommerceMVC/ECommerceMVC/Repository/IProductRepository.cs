using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<ShoppingProductsViewModel> GetAllProducts();
        Product GetById(int id);
    }
}
