using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;

namespace Siged.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
