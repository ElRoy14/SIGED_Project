using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string? IdentificationCard { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? UserPassword { get; set; }

    public int? RolId { get; set; }

    public int? JobTitleId { get; set; }

    public int? DepartmentId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Evaluator> Evaluators { get; } = new List<Evaluator>();

    public virtual JobTitle? JobTitle { get; set; }

    public virtual ICollection<Payroll> Payrolls { get; } = new List<Payroll>();

    public virtual ICollection<PerformanceEvaluation> PerformanceEvaluations { get; } = new List<PerformanceEvaluation>();

    public virtual Rol? Rol { get; set; }

    public virtual ICollection<ServicePaymentInvoice> ServicePaymentInvoices { get; } = new List<ServicePaymentInvoice>();

    public virtual ICollection<TasksEmployee> TasksEmployees { get; } = new List<TasksEmployee>();
}
