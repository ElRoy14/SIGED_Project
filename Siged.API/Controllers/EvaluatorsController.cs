using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Evaluators.DTOs;
using Siged.Application.Evaluators.Interfaces;
using Siged.Application.Salarys.DTOs;

namespace Siged.API.Controllers
{
    [Authorize]
    public class EvaluatorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IEvaluatorsService _evaluatorsService;

        public EvaluatorsController(IEvaluatorsService evaluatorsService)
        {
            _evaluatorsService = evaluatorsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluators()
        {
            var response = new Response<List<GetEvaluators>>();

            try
            {
                response.status = true;
                response.value = await _evaluatorsService.GetEvaluatorsAsync();
                response.message = "Successful evaluators";
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
