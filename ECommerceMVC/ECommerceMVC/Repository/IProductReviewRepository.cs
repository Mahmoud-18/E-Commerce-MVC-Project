using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IProductReviewRepository
    {
        void Insert(ProductReview productReview);
        List<ProductReview> GetAll();
        List<ProductReview> GetById(int productId); // the id of the product
    }
}
