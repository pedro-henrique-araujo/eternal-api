namespace Eternal.Models
{
    public class AuthorizationDto
    {
        public string JwtToken { get; set; }

        public AuthorizationDto(string jwtToken)
        {
            JwtToken = jwtToken;
        }
    }
}
