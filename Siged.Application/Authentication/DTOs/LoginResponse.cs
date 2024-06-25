namespace Siged.Application.Authentication.DTOs
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? RolDescription { get; set; }

    }

}
