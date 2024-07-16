using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.TaskEmployees.DTOs;
using Siged.Application.TaskEmployees.Interfaces;
using Siged.Application.Users.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class TasksEmployeeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Users = _userService.GetAllUserAsync();

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

        private readonly ITaskEmployeeService _taskEmployeeService;
        private readonly IUserService _userService;

        public TasksEmployeeController(ITaskEmployeeService taskEmployeeService, IUserService userService)
        {
            _taskEmployeeService = taskEmployeeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var response = new Response<List<GetTask>>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.GetAllTaskAsync();
                response.message = "Successful taks";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateTask task)
        {
            var response = new Response<GetTask>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.CreateTask(task);
                response.message = "Successful registration";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllPendingTask()
        {
            var response = new Response<List<GetTask>>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.GetAllPendingTaskAsync();
                response.message = "Successful taks";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllTaskListDone()
        {
            var response = new Response<List<GetTask>>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.GetAllTaskListDoneAsync();
                response.message = "Successful taks";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetPendingTaskByUser(int userId)
        {
            var response = new Response<List<GetTask>>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.GetPendingTaskByEmployee(userId);
                response.message = "Successful pending tasks";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetDoneTaskByUser(int userId)
        {
            var response = new Response<List<GetTask>>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.GetTaskDoneByEmployee(userId);
                response.message = "Successful pending tasks";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> EditTask([FromBody] UpdateTask task)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.UpdateAsync(task);
                response.message = "Task information updated successfully";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> EditTaskState([FromBody] UpdateStateTask task)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.UpdateStateAsync(task);
                response.message = "Task information updated successfully";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _taskEmployeeService.DeleteAsync(id);
                response.message = "Task information successfully deleted";
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
