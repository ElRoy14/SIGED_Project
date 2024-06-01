namespace Siged.Domain.Entities;

public partial class Rol
{
    public int RolId { get; set; }
    public string? NameRol { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
