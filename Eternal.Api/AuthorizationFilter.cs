using Eternal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Eternal.Api
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly AppSettings _appSettings;

        public AuthorizationFilter(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public void OnAuthorization(AuthorizationFilterContext authContext)
        {

            if (ShouldSkipAuthorization(authContext)) return;

            var jwtToken = ExtractToken(authContext);
            var id = jwtToken?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (id == _appSettings.Id) return;

            authContext.Result = new JsonResult(new
            {
                message = "Unauthorized"
            })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        private JwtSecurityToken? ExtractToken(AuthorizationFilterContext authContext)
        {
            if (_appSettings.Secret is null) return null;
            var authHeader = authContext.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            var token = authHeader?.Split(" ")?.Last();
            if (token is null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                return jwtToken;
            }
            catch (SecurityTokenExpiredException)
            {
                return null;
            }

            return null;
        }

        private bool ShouldSkipAuthorization(AuthorizationFilterContext authContext)
        {
            var endpoint = authContext.HttpContext.GetEndpoint();
            return endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;
        }
    }
}
