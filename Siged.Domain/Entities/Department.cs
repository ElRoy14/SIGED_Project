namespace Siged.Domain.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
