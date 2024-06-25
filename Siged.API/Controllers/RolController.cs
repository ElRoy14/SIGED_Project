using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Roles.DTOs;
using Siged.Application.Roles.Interfaces;

namespace Siged.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class RolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        //[Authorize]
        [HttpGet]
        //[Route("GetAllRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var response = new Response<List<GetRol>>();

            try
            {
                response.status = true;
                response.value = await _rolService.GetAllRolesAsync();
                response.message = "Successful roles";
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
