using Eternal.Models;

namespace Eternal.Business
{
    public interface IJwtTokenService
    {
        AuthorizationDto? GenerateJwtToken(string id);
    }
}