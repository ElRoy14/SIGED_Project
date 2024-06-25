
using Siged.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Attendances.DTOs
{
    public class CreateCheckIn
    {
        public int? UserId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public TimeSpan? CheckIn { get; set; }
        

    }
}
