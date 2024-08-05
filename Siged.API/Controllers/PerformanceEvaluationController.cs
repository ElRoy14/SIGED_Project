using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Evaluators.Interfaces;
using Siged.Application.Goals.Interfaces;
using Siged.Application.PerformanceEvaluations.DTOs;
using Siged.Application.PerformanceEvaluations.Interfaces;
using Siged.Application.Salarys.DTOs;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PerformanceEvaluationController : Controller
    {
        private readonly IPerformanceEvaluationService _performanceEvaluationService;
        private readonly IUserService _userService;
        private readonly IGoalsService _goalsService;
        private readonly IEvaluatorsService _evaluatorsService;




        public IActionResult PerformanceEvaluationList()
        {
            return View();
        }

      

        public PerformanceEvaluationController(IPerformanceEvaluationService performanceEvaluationService, IUserService userService, IGoalsService goalsService, IEvaluatorsService evaluatorsService)
        {
            _performanceEvaluationService = performanceEvaluationService;
            _userService = userService;
            _goalsService = goalsService;
            _evaluatorsService = evaluatorsService;

        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Users = await _userService.GetAllUserAsync();
            ViewBag.Goals = await _goalsService.GetAllGoalsAsync();
            ViewBag.performanceEvaluationService = await _performanceEvaluationService.GetAllPerformanceAsycn();
            ViewBag.evaluatorsService = await _evaluatorsService.GetEvaluatorsAsync();

            return View();
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

        [HttpGet]
        public async Task<IActionResult> GetPerformanceById(int id)
        {
            var response = new Response<GetPerformanceEvaluation>();
            try
            {
                var user = await _performanceEvaluationService.GetPerformanceById(id);
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

    }

}
