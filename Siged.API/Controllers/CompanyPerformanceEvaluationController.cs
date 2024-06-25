using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Siged.API.Controllers
{
    [Authorize]
    public class CompanyPerformanceEvaluationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
