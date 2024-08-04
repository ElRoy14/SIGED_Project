using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.AppliedTaxes.DTOs;
using Siged.Application.AppliedTaxes.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class AppliedTaxesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IAppliedTaxesService _appliedTaxesService;

        public AppliedTaxesController(IAppliedTaxesService appliedTaxesService)
        {
            _appliedTaxesService = appliedTaxesService;
        }

        public async Task<IActionResult> GetAllAppliedTaxes() 
        {
            var response = new Response<List<GetAppliedTaxe>>();

            try
            {
                response.status = true;
                response.value = await _appliedTaxesService.GetAppliedTaxeListAsync();
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
