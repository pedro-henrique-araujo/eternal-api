using Eternal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Eternal.Api
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly HttpContext _httpContext;
        private readonly AppSettings _appSettings;

        public AuthorizationFilter(HttpContext context, IOptions<AppSettings> appSettings)
        {
            _httpContext = context;
            _appSettings = appSettings.Value;
        }

        public void OnAuthorization(AuthorizationFilterContext authContext)
        {
            var token = _httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (id == _appSettings.Id) return;
            authContext.Result = new JsonResult(new
            {
                message = "Unauthorized"
            })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}
