using Eternal.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eternal.Api.Controllers
{
    [ApiController, Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpGet("{id}"), AllowAnonymous]
        public ActionResult GetToken([FromRoute] string id)
        {
            var output = _jwtTokenService.GenerateJwtToken(id);
            return Ok(output);
        }
    }
}
