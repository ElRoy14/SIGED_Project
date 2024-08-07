using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendances.DTOs
{
    public class CheckOut
    {
        public int AttendanceId { get; set; }
        public int? UserId { get; set; }
        public TimeSpan? Check_Out { get; set; }
    }
}
