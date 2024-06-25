
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendances.DTOs
{
    public class GetAttendance
    {
        public int AttendanceId { get; set; }
        public int? UserId { get; set; }
        public string UserDescription { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public decimal? HoursWorked { get; set; }
        
    }
}
