using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Roles.DTOs;
using Siged.Application.TaskStatusEmployees.DTOs;
using Siged.Application.TaskStatusEmployees.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class TaskStatusEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ITaskStatusEmployeeService _taskStatusEmployeeService;

        public TaskStatusEmployeeController(ITaskStatusEmployeeService taskStatusEmployeeService)
        {
            _taskStatusEmployeeService = taskStatusEmployeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskStatus()
        {
            var response = new Response<List<GetTaskStatusEmployee>>();

            try
            {
                response.status = true;
                response.value = await _taskStatusEmployeeService.GetAllTaskStatusEmployeeAsync();
                response.message = "Successful state";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

    }

}
