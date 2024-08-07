using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Customers.DTOs;
using Siged.Application.Customers.Interfaces;
using Siged.Application.Email.DTOs;
using Siged.Application.Email.Interface;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customrService;
        private readonly IEmailService _emailService;

        public CustomerController(ICustomerService customrService, IEmailService emailService) {

            _customrService = customrService;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllCustomer()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomr()
        {
            var response = new Response<List<GetCustomer>>();
            try
            {
                response.status = true;
                response.value = await _customrService.GetAllCustomerAsync();
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
        public async Task<IActionResult> Register([FromBody] CreateCustomer user)
        {
            var response = new Response<GetCustomer>();
            try
            {
                response.status = true;
                response.value = await _customrService.Register(user);
                response.message = "Registro exitoso";
                _emailService.SendEmail(GenerateEmailData(user));
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditCustomer([FromBody] UpdateCustomer user)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _customrService.UpdateAsync(user);
                response.message = "User information updated successfully";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomrById(int id)
        {
            var response = new Response<GetCustomer>();
            try
            {
                var user = await _customrService.GetCustomerByIdAsync(id);
                if (user != null)
                {
                    response.status = true;
                    response.value = user;
                    response.message = "User found";
                }
                else
                {
                    response.status = false;
                    response.message = $"Customes with id {id} not found";
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _customrService.DeleteAsync(id);
                response.message = "Customes information successfully deleted";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        private EmailDto GenerateEmailData(CreateCustomer user)
        {
            return new EmailDto
            {
                Addresee = user.Email,
                Subject = "Cliente Registrado Exitosamente",
                Body = $"<body style=\"font-family: Arial, sans-serif; line-height: 1.6; color: #333; margin: 0; padding: 0; background-color: #f4f4f4;\">\r\n    <div style=\"width: 100%; max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\">\r\n " +
                "<div style=\"background-color: #4CAF50; color: white; padding: 10px 0; text-align: center;\">\r\n " +
                "<h1 style=\"margin: 0;\">Cliente Registrado Exitosamente</h1>\r\n " +
                "</div>\r\n " +
                "<div style=\"margin: 20px 0;\">\r\n " +
                $"<p>Hola {user.FullName},</p>\r\n " +
                "<p>Nos hace muy feliz que nos prefieras.</p>\r\n " +
                "<p>Por este medio nos estaremos comunicando con relación a notificaciones de pagos y confirmación de citas.</p>\r\n  " +
                "<p>Saludos cordiales,<br>SIGED COMPANY</p>\r\n " +
                "</div>\r\n  " +
                "<div style=\"text-align: center; color: #888; font-size: 12px; margin-top: 20px; padding-top: 10px; border-top: 1px solid #eee;\">\r\n  " +
                "<p>Este es un mensaje generado automáticamente. Por favor, no responda a este correo.</p>\r\n " +
                "</div>\r\n    </div>\r\n</body>"
            };
        }
    }
}

