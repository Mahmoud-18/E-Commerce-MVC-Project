using Castle.Core.Resource;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ECommerceMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        IBrandRepository _brands;
        IProductRepository _products;
        public BrandController(IBrandRepository brands)
        {
            _brands = brands;
        }
        public IActionResult Index()
        {
            var brandss = _brands.GetAll();
            return View(brandss);
        }
        public IActionResult BrandDetails(int id)
        {
            var brand = _brands.GetById(id);
            return View(brand);
        }
        public IActionResult EditBrand(int id)
        {
            var brand = _brands.GetById(id);
            return View(brand);

        }
        [HttpPost]
        public async Task<IActionResult> EditBrand([FromRoute] int id, Brand brand)
        {
    

            if (brand.Name != null)

            {
                 brand.UpdatedOnUtc= DateTime.UtcNow;
                _brands.Update(id,brand);
                return RedirectToAction("Index");
            }
            else
            {
        
                return View(brand);
            }
        }
        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddBrand(Brand nbrand)
        { if (nbrand.Name != null)
            {
              nbrand.CreatedOnUtc = DateTime.UtcNow;
                _brands.Insert(nbrand);
                return RedirectToAction("Index");

            }
            else
            {
               
                return View("AddBrand",nbrand);
            }
        }
        public IActionResult Delete(int id)
        {
           
            _brands.Delete(id);
            return NoContent();
        }
    }
}
