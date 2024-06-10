using Siged.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendance.DTOs
{
    public class CheckIn
    {
        public int? UserId { get; set; }
        public virtual UserInfo? User { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public TimeSpan? Check_In { get; set; }
    }
}
