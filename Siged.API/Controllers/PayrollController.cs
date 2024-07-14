using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Payrolls.DTOs;
using Siged.Application.Payrolls.Interfaces;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Salarys.DTOs;
using Siged.Application.Users.DTOs;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PayrollController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPayroll()
        {
            var response = new Response<List<GetPayroll>>();

            try
            {
                response.status = true;
                response.value = await _payrollService.GetAllPayrollsAsync();
                response.message = "Successful payroll";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreatePayroll payroll)
        {
            var response = new Response<GetPayroll>();

            try
            {
                response.status = true;
                response.value = await _payrollService.Register(payroll);
                response.message = "Successful registration";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> EditPayroll([FromBody] UpdatePayroll payroll)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _payrollService.UpdateAsync(payroll);
                response.message = "Payroll information updated successfully";
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayroll(int id)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _payrollService.DeleteAsync(id);
                response.message = "User information successfully deleted";
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
