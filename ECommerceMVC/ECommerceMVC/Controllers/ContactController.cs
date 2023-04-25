using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Submit(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // TODO: Send email or save data to database

            TempData["Message"] = "Your message has been sent. Thank you!";
            return RedirectToAction("Index");
        }

    }
}
