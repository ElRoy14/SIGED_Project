using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Customers.DTOs;
using Siged.Application.ServicePaymentInvoices.DTOs;
using Siged.Application.ServicePaymentInvoices.Interfaces;

namespace Siged.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class ServicePaymentInvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IServicePaymentInvoiceService _servicePaymentInvoiceService;

        public ServicePaymentInvoiceController(IServicePaymentInvoiceService servicePaymentInvoiceService)
        {
            _servicePaymentInvoiceService = servicePaymentInvoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoice()
        {
            var response = new Response<List<GetServicePaymentInvoice>>();
            try
            {
                response.status = true;
                response.value = await _servicePaymentInvoiceService.GetPaymentInvoicesAsync();
                response.message = "Successful data";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateServicePaymentInvoice paymentInvoice)
        {
            var response = new Response<GetServicePaymentInvoice>();
            try
            {
                response.status = true;
                response.value = await _servicePaymentInvoiceService.Register(paymentInvoice);
                response.message = "Registro exitoso";
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
