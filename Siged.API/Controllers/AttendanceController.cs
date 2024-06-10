using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siged.API.Utility;
using Siged.Application.Attendance.DTOs;
using Siged.Application.Attendance.Interfaces;

namespace Siged.API.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: AttendanceController1
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

        // POST: AttendanceController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckIn(GetAttendance attendance)
        {
            var response = new Response<CheckIn>();

            try
            {
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckOut(GetAttendance attendance)
        {
            var response = new Response<CheckOut>();

            try
            {
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
