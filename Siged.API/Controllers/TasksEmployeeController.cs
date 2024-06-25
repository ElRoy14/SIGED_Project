using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Siged.API.Controllers
{
    [Authorize]
    public class TasksEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaskListDone()
        {
            return View();
        }

        public IActionResult PendingTask()
        {
            return View();
        }

        public IActionResult TaskDone()
        {
            return View();
        }

    }
}
