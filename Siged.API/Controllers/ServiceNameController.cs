using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.ServiceNames.DTOs;
using Siged.Application.ServiceNames.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class ServiceNameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IServiceNamesService _serviceNamesService;

        public ServiceNameController(IServiceNamesService serviceNamesService)
        {
            _serviceNamesService = serviceNamesService;
        }

        public async Task<IActionResult> GetAllServiceName() 
        {
            var response = new Response<List<GetServiceName>>();
            try
            {
                response.status = true;
                response.value = await _serviceNamesService.GetAllServiceNamesAsync();
                response.message = "Successful data";
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
