using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        ProductDetailsViewModel GetById(int id);
    }
}
