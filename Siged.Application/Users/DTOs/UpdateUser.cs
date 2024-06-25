namespace Siged.Application.Users.DTOs
{
    public class UpdateUser
    {
        public int UserId { get; set; }
        public string? IdentificationCard { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public int? RolId { get; set; }
        public int? JobTitleId { get; set; }
        public int? DepartmentId { get; set; }
        public int? IsActive { get; set; }

    }

}
