using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Repository
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly EcommerceDbContext context;

        public ProductReviewRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
        public List<ProductReview> GetById(int productId)
        {
            return context.ProductReviews.Include(p=>p.Product).Where(p => p.ProductId == productId).ToList();
        }
        public List<ProductReview> GetAll()
        {
            return context.ProductReviews.ToList();
        }
        public void Insert(ProductReview productReview)
        {
            context.ProductReviews.Add(productReview);
            context.SaveChanges();
        }
    }
}
