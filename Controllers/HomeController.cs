using FirstResponsiveWebAppStonehocker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FirstResponsiveWebAppStonehocker.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FV = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AgeThisYear model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Name = model.Name; //Here so that Index can reference Name to ensure it is not Null
                ViewBag.FV = model.CalculateAge(DateOnly.FromDateTime(DateTime.Today));
            }
            else { ViewBag.FV = 0; }
            return View(model);
        }

    }
}
