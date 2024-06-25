using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class TasksEmployee
{
    public int TaskId { get; set; }

    public string? NameTask { get; set; }

    public DateTime? StartDate { get; set; }

    public string? DueDate { get; set; }

    public int? UserId { get; set; }

    public int? TaskStatusId { get; set; }

    public virtual TaskStatusEmployee? TaskStatus { get; set; }

    public virtual UserInfo? User { get; set; }
}
