using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class CountryController : Controller
    {
        ICountryRepository _countries;
       
        public CountryController(ICountryRepository country)
        {
            _countries = country;      
        }
        public IActionResult Index()
        {
            var country = _countries.GetAll();
            return View(country);
        }

        public IActionResult EditCountry(int id)
        {
            var c = _countries.GetById(id);
            return View(c);

        }
        [HttpPost]
        public async Task<IActionResult> EditCountry([FromRoute] int id, Country country)
        {


            if (country.Code != null)

            {
           
                _countries.Update(id, country);
                return RedirectToAction("Index");
            }
            else
            {
     
                return View(country);
            }
        }
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddCountry(Country country)
        {
            if (country.Code != null)
            {
    
                _countries.Insert(country);
                return RedirectToAction("Index");

            }
            else
            {

                return View( country);
            }
        }


        public IActionResult Delete(int id)
        {

            _countries.Delete(id);
            return NoContent();
        }
    }
}
