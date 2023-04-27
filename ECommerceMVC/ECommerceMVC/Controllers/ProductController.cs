using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers;

public class ProductController : Controller
{
    IProductRepository productRepository;
    public ProductController(IProductRepository _productRepository)
    {
        productRepository = _productRepository;
    }

    public IActionResult ProductDetails(int id)
    {
        return View(productRepository.GetById(id));
    }
}
