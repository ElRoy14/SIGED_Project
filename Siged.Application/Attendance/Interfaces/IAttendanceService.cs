using Siged.Application.Attendance.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendance.Interfaces
{
    public interface IAttendanceService
    {
        Task<List<GetAttendance>> GetAllAttendanceAsync();
        Task<GetAttendance> GetAttendanceByIdAsync(int id);
        Task<CheckIn> CheckIn(GetAttendance attendance);
        Task<CheckOut> CheckOut(GetAttendance attendance);
    }
}
