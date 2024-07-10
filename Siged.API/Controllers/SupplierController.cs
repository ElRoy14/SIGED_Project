using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Customers.DTOs;
using Siged.Application.Customers.Interfaces;
using Siged.Application.Customers.Servicices;
using Siged.Application.Suppliers.DTOs;
using Siged.Application.Suppliers.Interfaces;

namespace Siged.API.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllSupplier()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplier()
        {
            var response = new Response<List<GetSuppliers>>();
            try
            {
                response.status = true;
                response.value = await _supplierService.GetAllCustomerAsync();
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
        public async Task<IActionResult> Register([FromBody] CreateSuppliers user)
        {
            var response = new Response<GetSuppliers>();
            try
            {
                response.status = true;
                response.value = await _supplierService.Register(user);
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
        public async Task<IActionResult> EditSupplier([FromBody] UpdateSuppliers user)
        {
            var response = new Response<bool>();
            try
            {
                response.status = true;
                response.value = await _supplierService.UpdateAsync(user);
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
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var response = new Response<GetSuppliers>();
            try
            {
                var user = await _supplierService.GetCustomerByIdAsync(id);
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
                response.value = await _supplierService.DeleteAsync(id);
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
