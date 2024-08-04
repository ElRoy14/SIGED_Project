using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.PaymentMethods.DTOs;
using Siged.Application.PaymentMethods.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PaymentMethodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService) 
        { 
            _paymentMethodService = paymentMethodService;
        }

        public async Task<IActionResult> GetAllPaymentMethod() 
        {
            var response = new Response<List<GetPaymentMethods>>();
            try
            {
                response.status = true;
                response.value = await _paymentMethodService.GetAllPaymentMethods();
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
