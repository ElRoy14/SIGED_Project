using Siged.Application.Menus.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.Menus.Interfaces
{
    public interface IMenuService
    {
        Task<List<GetMenu>> GetListAsync(int userId);
    }
}
