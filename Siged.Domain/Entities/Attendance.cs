using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int? UserId { get; set; }

    public DateTime? AttendanceDate { get; set; }

    public TimeSpan? CheckIn { get; set; }

    public TimeSpan? CheckOut { get; set; }

    public decimal? HoursWorked { get; set; }

    public virtual UserInfo? User { get; set; }
}
