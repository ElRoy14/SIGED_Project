namespace Siged.Domain.Entities;

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
    public int? SalaryId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public virtual ICollection<Attendance> Attendances { get; } = new List<Attendance>();
    public virtual Department? Department { get; set; }
    public virtual JobTitle? JobTitle { get; set; }
    public virtual Rol? Rol { get; set; }
    public virtual Salary? Salary { get; set; }
}
