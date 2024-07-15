using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Goals.DTOs;
using Siged.Application.Goals.Interfaces;
using Siged.Application.Salarys.DTOs;

namespace Siged.API.Controllers
{
    [Authorize]
    public class GoalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IGoalsService _goalsService;

        public GoalsController(IGoalsService goalsService)
        {
            _goalsService = goalsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            var response = new Response<List<GetGoals>>();

            try
            {
                response.status = true;
                response.value = await _goalsService.GetAllGoalsAsync();
                response.message = "Successful goals";
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
