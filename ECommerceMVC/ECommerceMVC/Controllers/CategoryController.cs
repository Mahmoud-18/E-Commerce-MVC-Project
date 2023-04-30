using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommerceMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;


        public CategoryController(ICategoryRepository _categoryRepository, IProductRepository _product) 
        {
            categoryRepository = _categoryRepository;
            productRepository = _product;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }
    }
}
