using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.ActivitiesCalendar.Interfaces;
using Siged.Application.TaskEmployees.DTOs;
using Siged.Application.TaskEmployees.Interfaces;
using Siged.Application.TaskEmployees.Services;
using Siged.Application.Users.Interfaces;
using Siged.Domain.Entities;

namespace Siged.API.Controllers
{
    [Authorize]
    public class ActivitiesCalendarController : Controller
    {
        private readonly IActivitiesCalendarService _activitiesCalendarService;

        public ActivitiesCalendarController(IActivitiesCalendarService activitiesCalendarService)
        {
            _activitiesCalendarService = activitiesCalendarService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var response = new Response<List<Event>>();

            try
            {
                response.status = true;
                response.value = await _activitiesCalendarService.GetEvents();
                response.message = "Successful events";
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
