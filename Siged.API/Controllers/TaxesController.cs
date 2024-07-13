using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Roles.DTOs;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Roles.Services;
using Siged.Application.Tax.DTOs;
using Siged.Application.Tax.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class TaxesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly ITaxesService _taxesService;

        public TaxesController(ITaxesService taxesService)
        {
            _taxesService = taxesService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTaxes()
        {
            var response = new Response<List<GetTaxes>>();

            try
            {
                response.status = true;
                response.value = await _taxesService.GetAllTaxesAsync();
                response.message = "Successful taxes";
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
