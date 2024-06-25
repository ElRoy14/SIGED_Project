using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PerformanceEvaluationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PerformanceEvaluationList()
        {
            return View();
        }
    }
}
