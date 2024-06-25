using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Siged.API.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllCustomer()
        {
            return View();
        }
    }
}
