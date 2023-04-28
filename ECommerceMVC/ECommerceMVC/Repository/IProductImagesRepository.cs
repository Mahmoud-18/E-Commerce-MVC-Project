using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductImagesRepository
    {
        List<ProductImages> GetAll();
        ProductImages GetById(int id);
        void Insert(ProductImages productImages);
        void Update(int id, ProductImages productImages);
        void Delete(int id);
    }
}
