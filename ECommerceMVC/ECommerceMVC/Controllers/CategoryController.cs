using Castle.Core.Resource;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory()
        {

            ViewData["CategoryList"] = categoryRepository.GetAll();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category newcategory)
        {
            if (ModelState.IsValid)
            {
                newcategory.CreatedAtUtc = DateTime.UtcNow;
                categoryRepository.Insert(newcategory);                
                return RedirectToAction("Index");
            }
            ViewData["CategoryList"] = categoryRepository.GetAll();
            return View(newcategory);
        }
        public IActionResult EditCategory(int id)
        {
            Category category = categoryRepository.GetById(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory([FromRoute] int id, Category category)
        {
            if (ModelState.IsValid)
            {
                category.UpdatedAtUtc = DateTime.UtcNow;
                categoryRepository.Update(id,category);               
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult CategoryDetails(int id)
        {
            Category category =categoryRepository.GetById(id);
            ViewData["CategoryList"] = categoryRepository.GetByParentCategoryId(id);
            return View(category);
        }

        public IActionResult DeleteCategory(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}

