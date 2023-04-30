using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class ProductImagesRepository : IProductImagesRepository
    {
        EcommerceDbContext context;

        public ProductImagesRepository(EcommerceDbContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            ProductImages productImages = GetById(id);
            context.ProductImages.Remove(productImages);
            context.SaveChanges();
        }

        public List<ProductImages> GetAll()
        {
            return context.ProductImages.ToList();
        }

        public ProductImages GetById(int id)
        {
            return context.ProductImages.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(ProductImages productImages)
        {
            context.ProductImages.Add(productImages);
            context.SaveChanges();
        }

        public void Update(int id, ProductImages productImages)
        {
            context.Update(productImages);
            context.SaveChanges();
        }
    }
}
