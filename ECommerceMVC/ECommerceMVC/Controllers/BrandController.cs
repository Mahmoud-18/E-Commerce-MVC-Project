using Castle.Core.Resource;
using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ECommerceMVC.Controllers
{
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
                Brand old = _brands.GetById(id);
                old.Name = brand.Name;
                old.Image = brand.Image;
                _brands.Update(id,old);
                return RedirectToAction("Index");
            }
            else
            {
                Brand bb = new Brand();
                bb.Id = id;
                bb.Name = brand.Name;
                bb.Image = brand.Image;
                return View(bb);
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
                Brand newwBrand = new Brand();
                newwBrand.Name = nbrand.Name;
                newwBrand.Image = nbrand.Image;
                _brands.Insert(newwBrand);
                return RedirectToAction("Index");

            }
            else
            {
                Brand newwBrand = new Brand();
                newwBrand.Name = nbrand.Name;
                newwBrand.Image = nbrand.Image;
                return View("AddBrand",newwBrand);
            }
        }


        public IActionResult Delete(int id)
        {
           
            _brands.Delete(id);
            return NoContent();
        }
    }
}
