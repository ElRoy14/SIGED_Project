using Siged.Application.Authentication.DTOs;

namespace Siged.Application.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(string email, string password);
    }

}
