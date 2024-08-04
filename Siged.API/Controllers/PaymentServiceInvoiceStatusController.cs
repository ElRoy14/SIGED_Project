using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.PaymenInvoiceStatus.DTOs;
using Siged.Application.PaymenInvoiceStatus.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PaymentServiceInvoiceStatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IPaymentServiceInvoiceStatusService _paymentServiceInvoiceStatus;

        public PaymentServiceInvoiceStatusController(
            IPaymentServiceInvoiceStatusService paymentServiceInvoiceStatus
            )
        {
            _paymentServiceInvoiceStatus = paymentServiceInvoiceStatus;
        }

        public async Task<IActionResult> GetAllPaymentServiceInvoiceStatus()
        {
            var response = new Response<List<GetPaymentServiceInvoiceStatus>>();

            try
            {
                response.status = true;
                response.value = await _paymentServiceInvoiceStatus.GetAllPaymentServiceInvoiceStatusAsync();
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
