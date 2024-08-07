using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.AppliedTaxes.Interfaces;
using Siged.Application.Customers.DTOs;
using Siged.Application.DiscountsService.Interface;
using Siged.Application.PaymenInvoiceStatus.Interfaces;
using Siged.Application.PaymentMethods.Interfaces;
using Siged.Application.ServiceNames.Interfaces;
using Siged.Application.ServicePaymentInvoices.DTOs;
using Siged.Application.ServicePaymentInvoices.Interfaces;
using Siged.Application.Users.Interfaces;
using Siged.Application.Users.Services;

namespace Siged.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class ServicePaymentInvoiceController : Controller
    {
       
   
        private readonly IServicePaymentInvoiceService _servicePaymentInvoiceService;
        private readonly IServiceNamesService _serviceNamesService;
        private readonly IPaymentMethodService _paymentMethodService; 
        private readonly IDiscountService _discountService;
        private readonly IAppliedTaxesService _appliedTaxesService; 
        private readonly IPaymentServiceInvoiceStatusService _paymentServiceInvoiceStatusService;
        private readonly IUserService _userService;

        public ServicePaymentInvoiceController(
         IServicePaymentInvoiceService servicePaymentInvoiceService,
         IServiceNamesService serviceNamesService,
         IPaymentMethodService paymentMethodService,
         IDiscountService discountService,
         IAppliedTaxesService appliedTaxesService,
         IPaymentServiceInvoiceStatusService paymentServiceInvoiceStatusService,
         IUserService userService) // Corregido: userService en lugar de _userService
        {
            _servicePaymentInvoiceService = servicePaymentInvoiceService;
            _serviceNamesService = serviceNamesService;
            _paymentMethodService = paymentMethodService;
            _discountService = discountService;
            _appliedTaxesService = appliedTaxesService;
            _paymentServiceInvoiceStatusService = paymentServiceInvoiceStatusService;
            _userService = userService; // Inicialización correcta del servicio de usuarios
        }

        // Métodos adicionales del controlador aquí

        public async Task<IActionResult> Index()
        {
            ViewBag.ServiceNames = await _serviceNamesService.GetAllServiceNamesAsync();
            ViewBag.PaymentMethods = await _paymentMethodService.GetAllPaymentMethods();
            ViewBag.Discounts = await _discountService.GetDiscountsAsync();
            ViewBag.AppliedTaxes = await _appliedTaxesService.GetAppliedTaxeListAsync();
            ViewBag.PaymentServiceInvoiceStatuses = await _paymentServiceInvoiceStatusService.GetAllPaymentServiceInvoiceStatusAsync();
            ViewBag.Users = await _userService.GetAllUserAsync(); // Llenar ViewBag con usuarios

            return View();
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
