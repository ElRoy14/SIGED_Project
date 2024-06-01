using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Authentication.DTOs;
using Siged.Application.Authentication.Interfaces;

namespace Siged.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginRequest login)
        {
            var response = new Response<LoginResponse>();

            try
            {
                response.status = true;
                response.value = await _authService.Login(login.Email, login.UserPassword);
                response.message = "User logged in successfully";
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
