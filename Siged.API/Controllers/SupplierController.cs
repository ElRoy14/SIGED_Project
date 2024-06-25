using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Siged.API.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllSupplier()
        {
            return View();
        }
    }
}
