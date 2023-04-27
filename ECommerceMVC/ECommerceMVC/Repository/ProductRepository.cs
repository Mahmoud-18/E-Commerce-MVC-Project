using ECommerceMVC.Context;
using ECommerceMVC.Models;
using ECommerceMVC.ViewModels;

namespace ECommerceMVC.Repository;

public class ProductRepository : IProductRepository
{
    EcommerceDbContext context;

    public ProductRepository(EcommerceDbContext _context)
    {
        context = _context;
    }

    public List<Product> GetAll()
    {
        return context.Product.ToList();
    }

    public ProductDetailsViewModel GetById(int id) // the id shuld be the product
    {
        ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel();
        Product product = context.Product.FirstOrDefault(p => p.Id == id)!;
        ProductItem productItem = context.Product.FirstOrDefault(i => i.ProductId == id)!;
        List<ProductImages> productImages = context.ProductImages.Where(im => im.ProductItemId == productItem.Id).ToList();
        Brand brand = context.Brand.FirstOrDefault(b => b.Id == productItem.BrandId)!;
        productDetailsViewModel.Name = product.Name;
        productDetailsViewModel.price = (float)productItem.Price;
        productDetailsViewModel.Image = productImages.Select(img => img.ImageURL).ToList();
        productDetailsViewModel.Description = product.Description;
        productDetailsViewModel.CreatetAtUtc = productItem.CreatedAtUtc;
        productDetailsViewModel.SUK = productItem.SKU;
        productDetailsViewModel.StockUnits = productItem.StockQuantity;
        productDetailsViewModel.BrandName = brand.Name;
        productDetailsViewModel.BrandImage = brand.Image;
        return productDetailsViewModel;
    }
}
