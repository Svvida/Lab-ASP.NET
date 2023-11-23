using Lab_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(Birth model)
        {
            if ((bool)!model.IsValid())
            {
                ViewData["Message"] = "Wrong format data!";
                return View("error");
            }

            return View(model);
        }
    }
}
