namespace Waste_Management.WebApi.DTOs.UserDto
{
    public class LoginResponse
    {
        public required string JwtToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
