using Siged.Application.ServiceNames.DTOs;

namespace Siged.Application.ServiceNames.Interfaces
{
    public interface IServiceNamesService
    {
        Task<List<GetServiceName>> GetAllServiceNamesAsync();
    }

}
