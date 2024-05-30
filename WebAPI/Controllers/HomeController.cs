using Application.DTOs.Asistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Persistence.Queries.Asistencia;
using Persistence.Queries.Empleados;
using System.Diagnostics;
using WebAPI.Models;

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

            AsistenciaQueries asistenciaQueries = new AsistenciaQueries();

            BaseAsistenciaDTO asistencia = new BaseAsistenciaDTO();

            asistencia.Nombre = "Juan";
            asistencia.Apellido = "Pérez";
            asistencia.Fecha = DateTime.Parse("2024-05-30");
            asistencia.HoraSalida = Convert.ToDateTime("18:00:00.0000000");

            asistenciaQueries.RegistrarSalida(asistencia);

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
    }
}
