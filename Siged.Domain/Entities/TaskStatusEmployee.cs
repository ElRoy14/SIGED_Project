using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class TaskStatusEmployee
{
    public int TaskStatusId { get; set; }

    public string? TaskStatus { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<TasksEmployee> TasksEmployees { get; } = new List<TasksEmployee>();
}
