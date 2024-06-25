using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.JobTitles.DTOs;
using Siged.Application.JobTitles.Interfaces;

namespace Siged.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class JobTitleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IJobTitleService _jobTitleService;

        public JobTitleController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        //[Authorize]
        [HttpGet]
        //[Route("GetAllJobTitle")]
        public async Task<IActionResult> GetAllJobTitle()
        {
            var response = new Response<List<GetJobTitle>>();

            try
            {
                response.status = true;
                response.value = await _jobTitleService.GetAllJobTitleAsync();
                response.message = "Successful jobtitle";
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
