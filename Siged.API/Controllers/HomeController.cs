using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Siged.API.Models;

namespace WebAPI.Controllers
{
    
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

        public IActionResult login()
        {

            return View();
        }

        // Redirige a la acción Index del controlador Auth para mostrar la vista de inicio de sesión
        public IActionResult Privacy()
        {
            // return RedirectToAction("Index", "Auth");
            return View();
        }

       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
