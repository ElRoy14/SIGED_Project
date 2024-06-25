using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class JobTitle
{
    public int JobTitleId { get; set; }

    public string? JobTitleName { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<UserInfo> UserInfos { get; } = new List<UserInfo>();
}
