using Siged.Application.Attendances.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendances.Interfaces
{
    public interface IAttendanceService
    {
        Task<List<GetAttendance>> GetAllAttendanceAsync();
        Task<GetAttendance> GetAttendanceByIdAsync(int id);
        Task<CreateCheckIn> CheckIn(GetAttendance attendance);
        Task<CheckOut> CheckOut(GetAttendance attendance);
    }
}
