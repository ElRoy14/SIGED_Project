using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Customers.DTOs;
using Siged.Application.Departments.Interfaces;
using Siged.Application.Email.DTOs;
using Siged.Application.Email.Interface;
using Siged.Application.JobTitles.Interfaces;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Salarys.Interfaces;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siged.API.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRolService _rolService;
        private readonly IDepartamentService _departmentService;
        private readonly IJobTitleService _jobTitleService;
        private readonly ISalaryService _salaryService;
        private readonly IEmailService _emailService;

        public UserController(IUserService userService, IRolService rolService, IDepartamentService departmentService, IJobTitleService jobTitleService, ISalaryService salaryService, IEmailService emailService)
        {
            _userService = userService;
            _rolService = rolService;
            _departmentService = departmentService;
            _jobTitleService = jobTitleService;
            _salaryService = salaryService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            
            ViewBag.Roles = _rolService.GetAllRolesAsync().Result;
            ViewBag.Departments = _departmentService.GetAllDepartmentsAsync().Result;
            ViewBag.JobTitles = _jobTitleService.GetAllJobTitleAsync().Result;
            ViewBag.Salarys = _salaryService.GetAllSalaryAsync().Result;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = new Response<List<GetUser>>();
            try
            {
                response.status = true;
                response.value = await _userService.GetAllUserAsync();
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
        public async Task<IActionResult> Register([FromBody] CreateUser user)
        {
            var response = new Response<GetUser>();
            try
            {
                response.status = true;
                response.value = await _userService.Register(user);
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
        public async Task<IActionResult> EditUser([FromBody] UpdateUser user)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _userService.UpdateAsync(user);
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
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = new Response<GetUser>();
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user != null)
                {
                    response.status = true;
                    response.value = user;
                    response.message = "User found";
                }
                else
                {
                    response.status = false;
                    response.message = $"User with id {id} not found";
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _userService.DeleteAsync(id);
                response.message = "User information successfully deleted";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        private EmailDto GenerateEmailData(CreateUser user)
        {
            return new EmailDto
            {
                Addresee = user.Email,
                Subject = "Usuario Registrado Exitosamente",
                Body = $"<body style=\"font-family: Arial, sans-serif; line-height: 1.6; color: #333; margin: 0; padding: 0; background-color: #f4f4f4;\">\r\n    <div style=\"width: 100%; max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\">\r\n " +       
                "<div style=\"background-color: #4CAF50; color: white; padding: 10px 0; text-align: center;\">\r\n " +
                "<h1 style=\"margin: 0;\">Usuario Registrado Exitosamente</h1>\r\n " +
                "</div>\r\n "+
                "<div style=\"margin: 20px 0;\">\r\n "+
                $"<p>Hola {user.FullName},</p>\r\n "+
                "<p>Nos hace muy feliz que formes parte de nuestra empresa, y queremos notificarte que tu perfil fue creado exitosamente.</p>\r\n "+
                "<p>Por este medio nos estaremos comunicando con usted en relación de diversos temas.</p>\r\n  "+
                "<p>Saludos cordiales,<br>SIGED COMPANY</p>\r\n "+
                "</div>\r\n  "+
                "<div style=\"text-align: center; color: #888; font-size: 12px; margin-top: 20px; padding-top: 10px; border-top: 1px solid #eee;\">\r\n  "+
                "<p>Este es un mensaje generado automáticamente. Por favor, no responda a este correo.</p>\r\n "+
                "</div>\r\n    </div>\r\n</body>"
            };
        }
    }
}
