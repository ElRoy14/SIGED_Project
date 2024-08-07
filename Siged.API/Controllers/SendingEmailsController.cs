using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Customers.Interfaces;
using Siged.Application.Customers.Servicices;
using Siged.Application.Email.DTOs;
using Siged.Application.Email.Exceptions;
using Siged.Application.Email.Interface;

namespace Siged.API.Controllers
{
    [Authorize]
    public class SendingEmailsController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ICustomerService _customerService;

        public SendingEmailsController(IEmailService emailService, ICustomerService customerService)
        {
            _emailService = emailService;
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            ViewBag.Customers = _customerService.GetAllCustomerAsync().Result;

            return View();
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailDto request)
        {
            var response = new Response<EmailDto>();

            try
            {
                request.Body = $"<body style=\"font-family: Arial, sans-serif; line-height: 1.6; color: #333; margin: 0; padding: 0; background-color: #f4f4f4;\">\r\n    <div style=\"width: 100%; max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\">\r\n " +
                "<div style=\"background-color: #4CAF50; color: white; padding: 10px 0; text-align: center;\">\r\n " +
                $"<h1 style=\"margin: 0;\">{request.Subject}</h1>\r\n " +
                "</div>\r\n " +
                "<div style=\"margin: 20px 0;\">\r\n " +
                $"<p>Hola {request.Addresee},</p>\r\n " +
                $"<p>{request.Body}</p>\r\n  " +
                "<p>Saludos cordiales,<br>SIGED COMPANY</p>\r\n " +
                "</div>\r\n  " +
                "<div style=\"text-align: center; color: #888; font-size: 12px; margin-top: 20px; padding-top: 10px; border-top: 1px solid #eee;\">\r\n  " +
                "<p>Si detecta alguna actividad anomala por favor comunicarla por medio de este mismo correo electronico.</p>\r\n " +
                "</div>\r\n    </div>\r\n</body>";

                if (request == null)
                {
                    return NotFound();
                }
                response.status = true;
                _emailService.SendEmail(request);
                response.message = "Mail Sended Succesfully";
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
