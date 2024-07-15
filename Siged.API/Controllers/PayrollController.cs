using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Customers.DTOs;
using Siged.Application.Payrolls.DTOs;
using Siged.Application.Payrolls.Interfaces;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Salarys.DTOs;
using Siged.Application.Tax.Interfaces;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class PayrollController : Controller
    {
        private readonly IPayrollService _payrollService;
        private readonly IUserService _userService;
        private readonly ITaxesService _taxService;

        public PayrollController(IPayrollService payrollService, IUserService userService, ITaxesService taxService)
        {
            _payrollService = payrollService;
            _userService = userService;
            _taxService = taxService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Users = await _userService.GetAllUserAsync();
            ViewBag.Taxes = await _taxService.GetAllTaxesAsync();
            ViewBag.Payrolls = await _payrollService.GetAllPayrollsAsync();

            return View();
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

        [HttpGet]
        public async Task<IActionResult> GetPayrollById(int id)
        {
            var response = new Response<GetPayroll>();

            try
            {
                var payroll = await _payrollService.GetPayrollByIdAsync(id);

                if (payroll != null)
                {
                    response.status = true;
                    response.value = payroll;
                    response.message = "Payroll found";
                }
                else
                {
                    response.status = false;
                    response.message = $"Payroll with id {id} not found";
                }
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
