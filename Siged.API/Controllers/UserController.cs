using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.Types;
using Siged.API.Utility;
using Siged.Application.Departments.Interfaces;
using Siged.Application.JobTitles.Interfaces;
using Siged.Application.Roles.DTOs;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Salarys.Interfaces;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;
using Siged.Domain.Entities;

namespace Siged.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRolService _rolService;
        private readonly IDepartamentService _departmentService;
        private readonly IJobTitleService _jobTitleService;
        private readonly ISalaryService _salaryService;


        public UserController(IUserService userService, IRolService rolService, IDepartamentService departmentService, IJobTitleService jobTitleService, ISalaryService salaryService)
        {
            _userService = userService;
            _rolService = rolService;
            _departmentService = departmentService;
            _jobTitleService = jobTitleService;
            _salaryService = salaryService;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = _rolService.GetAllRolesAsync().Result;
            ViewBag.Departments = _departmentService.GetAllDepartmentsAsync().Result;
            ViewBag.JobTitles = _jobTitleService.GetAllJobTitleAsync().Result;
            ViewBag.Salarys = _salaryService.GetAllSalaryAsync().Result;
            return View();

        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var response = new Response<List<GetUser>>();

            try
            {
                response.status = true;
                response.value = await _userService.GetAllUserAsync();
                response.message = "Successful data";
                
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }
        // Controlador UserController.cs
        [Authorize]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CreateUser user)
        {
            var response = new Response<GetUser>();

            try
            {
                response.status = true;
                response.value = await _userService.Register(user);
                response.message = "Registration successful";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> EditUser([FromBody] UpdateUser user)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _userService.UpdateAsync(user);
                response.message = "User information updated successfully";
                
                
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteUser/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _userService.DeleteAsync(id);
                response.message = "User information successfully deleted";
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
