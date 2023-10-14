using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Lab_1.Controllers
{
    public enum Operators
    {
        UNKNOWN, ADD, SUB, MUL, DIV
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Calculator([FromQuery(Name ="operator")]Operators op, double? a, double? b)
        {
           if(a is null || b is null )
            {
                return View("Error");
            }
            switch (op)
            {
                case Operators.ADD:
                    ViewBag.op = a + b;
                    break;
                case Operators.SUB: ViewBag.op = a-b; break;
                case Operators.MUL: ViewBag.op = a * b; break;
                case Operators.DIV: ViewBag.op = a / b; break;
                default: return View("Error");
            }
            
            return View();
        }
    }
}