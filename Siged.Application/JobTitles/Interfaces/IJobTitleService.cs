using Siged.Application.JobTitles.DTOs;

namespace Siged.Application.JobTitles.Interfaces
{
    public interface IJobTitleService
    {
        Task<List<GetJobTitle>> GetAllJobTitleAsync();
    }

}
