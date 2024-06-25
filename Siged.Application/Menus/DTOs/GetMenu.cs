using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Menus.DTOs
{
    public class GetMenu
    {

        public string? DescriptionMenu { get; set; }

        public string? IconMenu { get; set; }

        public string? Controller { get; set; }

        public string? ActionPage { get; set; }

        public virtual ICollection<GetMenu> SubMenus { get; set; }
    }
}
