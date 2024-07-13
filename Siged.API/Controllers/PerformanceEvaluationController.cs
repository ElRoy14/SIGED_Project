using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.PerformanceEvaluations.DTOs;
using Siged.Application.PerformanceEvaluations.Interfaces;
using Siged.Application.Salarys.DTOs;
using Siged.Application.Users.DTOs;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PerformanceEvaluationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PerformanceEvaluationList()
        {
            return View();
        }

        private readonly IPerformanceEvaluationService _performanceEvaluationService;

        public PerformanceEvaluationController(IPerformanceEvaluationService performanceEvaluationService)
        {
            _performanceEvaluationService = performanceEvaluationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerformance()
        {
            var response = new Response<List<GetPerformanceEvaluation>>();

            try
            {
                response.status = true;
                response.value = await _performanceEvaluationService.GetAllPerformanceAsycn();
                response.message = "Successful performance";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreatePerformanceEvaluation performance)
        {
            var response = new Response<GetPerformanceEvaluation>();

            try
            {
                response.status = true;
                response.value = await _performanceEvaluationService.Register(performance);
                response.message = "Successful registration";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> EditPerformance([FromBody] UpdatePerformanceEvaluation performance)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _performanceEvaluationService.UpdateAsync(performance);
                response.message = "Performance information updated successfully";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePerformance(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _performanceEvaluationService.DeleteAsync(id);
                response.message = "Performance information successfully deleted";
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
