using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
    }
}
