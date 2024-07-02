using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Departments.Interfaces;
using Siged.Application.JobTitles.Interfaces;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Salarys.Interfaces;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siged.API.Controllers
{
    [Authorize]
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

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUser user)
        {
            var response = new Response<GetUser>();
            try
            {
                response.status = true;
                response.value = await _userService.Register(user);
                response.message = "Registro exitoso";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
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

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = new Response<GetUser>();
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user != null)
                {
                    response.status = true;
                    response.value = user;
                    response.message = "User found";
                }
                else
                {
                    response.status = false;
                    response.message = $"User with id {id} not found";
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
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
