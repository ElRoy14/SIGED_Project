using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Departments.DTOs;
using Siged.Application.Departments.Interfaces;

namespace Siged.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IDepartamentService _departamentService;

        public DepartmentController(IDepartamentService departamentService)
        {
            _departamentService = departamentService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            var response = new Response<List<GetDepartment>>();

            try
            {
                response.status = true;
                response.value = await _departamentService.GetAllDepartmentsAsync();
                response.message = "Successful departaments";
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
