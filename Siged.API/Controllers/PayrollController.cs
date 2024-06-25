using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PayrollController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
