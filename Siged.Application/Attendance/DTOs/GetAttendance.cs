using Siged.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendance.DTOs
{
    public class GetAttendance
    {
        public int AttendanceId { get; set; }
        public int? UserId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public decimal? HoursWorked { get; set; }
        public virtual UserInfo? User { get; set; }
    }
}
