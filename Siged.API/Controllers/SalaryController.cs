using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Salarys.DTOs;
using Siged.Application.Salarys.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalary()
        {
            var response = new Response<List<GetSalary>>();

            try
            {
                response.status = true;
                response.value = await _salaryService.GetAllSalaryAsync();
                response.message = "Successful salary";
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
