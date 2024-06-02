namespace Siged.Domain.Entities;

public partial class Salary
{
    public int SalaryId { get; set; }
    public string? Amount { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
