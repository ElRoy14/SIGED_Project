using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Authentication.DTOs;
using Siged.Application.Authentication.Interfaces;
using System.Threading.Tasks;

namespace Siged.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            var response = new Response<LoginResponse>();

            try
            {
                var result = await _authService.Login(login.Email, login.UserPassword);
                if (result != null)
                {
                    response.status = true;
                    response.value = result;
                    response.message = "User logged in successfully";
                }
                else
                {
                    response.status = false;
                    response.message = "Invalid login credentials";
                }
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
