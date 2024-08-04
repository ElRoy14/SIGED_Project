using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.DiscountsService.DTOs;
using Siged.Application.DiscountsService.Interface;

namespace Siged.API.Controllers
{
    [Authorize]
    public class DiscountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IActionResult> GetAllDiscount() 
        {
            var response = new Response<List<GetDiscount>>();
            try
            {
                response.status = true;
                response.value = await _discountService.GetDiscountsAsync();
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
