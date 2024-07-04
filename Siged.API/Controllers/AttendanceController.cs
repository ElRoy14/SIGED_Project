using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Attendances.DTOs;
using Siged.Application.Attendances.Interfaces;

namespace Siged.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Route("GetAllAttendance")]
        public async Task<ActionResult> GetAllAttendance()
        {
            var response = new Response<List<GetAttendance>>();
            
            try
            {
                response.status = true;
                response.value = await _attendanceService.GetAllAttendanceAsync();
                response.message = "Successful data";
            }
            catch(Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return View(response);
        }

        [HttpGet]
        public async Task<ActionResult> CheckIn()
        {
            return View();
        }

        // POST: AttendanceController1/Create
        [HttpPost]
        //[Route("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckIn(GetAttendance attendance)
        {
            var response = new Response<CreateCheckIn>();

            try
            {
                attendance.UserDescription = User.Identity.Name;

                response.status = true;
                response.value = await _attendanceService.CheckIn(attendance);
                response.message = "Check In successful";
            }
            catch(Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }
            return View(response);
        }

        // POST: AttendanceController1/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckOut(GetAttendance attendance)
        {
            var response = new Response<CheckOut>();

            try
            {
                attendance.UserDescription = User.Identity.Name;
                //attendance.UserId = User.Identity.NameIdentifier;

                response.status = true;
                response.value = await _attendanceService.CheckOut(attendance);
                response.message = "Check Out Successful";

            }catch(Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return View(response);
        }

    }
}
