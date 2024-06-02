using Siged.Application.Roles.DTOs;

namespace Siged.Application.Roles.Interfaces
{
    public interface IRolService
    {
        Task<List<GetRol>> GetAllRolesAsync();
    }

}
