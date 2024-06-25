using System;
using System.Collections.Generic;

namespace Siged.Domain;

public partial class Menu
{
    public int MenuId { get; set; }

    public string? DescriptionMenu { get; set; }

    public int? ParentMenuId { get; set; }

    public string? IconMenu { get; set; }

    public string? Controller { get; set; }

    public string? ActionPage { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Menu> InverseParentMenu { get; set; } = new List<Menu>();

    public virtual Menu? ParentMenu { get; set; }

    public virtual ICollection<RolMenu> RolMenus { get; set; } = new List<RolMenu>();
}
