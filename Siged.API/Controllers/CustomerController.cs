using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Customers.DTOs;
using Siged.Application.Customers.Interfaces;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customrService;
        public CustomerController(ICustomerService customrService) {

            _customrService = customrService;
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
    }
}

