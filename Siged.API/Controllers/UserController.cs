using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.Types;
using Siged.API.Utility;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;
using Siged.Domain.Entities;

namespace Siged.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Roles = _rolService.GetAllRolesAsync();
            return View();

        }

        private readonly IUserService _userService;
        private readonly IRolService _rolService;


        public UserController(IUserService userService, IRolService rolService)
        {
            _userService = userService;
            _rolService = rolService;
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

        [Authorize]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register([FromBody] CreateUser user)
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
