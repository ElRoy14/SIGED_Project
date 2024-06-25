using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Rol
{
    public int RolId { get; set; }

    public string? NameRol { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<RolMenu> RolMenus { get; } = new List<RolMenu>();

    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
