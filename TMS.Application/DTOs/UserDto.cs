namespace TMS.Application.DTOs
{
    public class UserDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}
