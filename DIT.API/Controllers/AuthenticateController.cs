using System.Threading.Tasks;
using DIT.API.Extentions;
using DIT.API.Services;
using DIT.Domain.Models.AuthModel;
using Microsoft.AspNetCore.Mvc;

namespace DIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTAuthService _authService;

        public AuthenticateController(IJWTAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }

            var token = await _authService.Authenticate(model.Username, model.Password);

            if (token.IsEmptyToken())
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshModel model)
        {

            return Ok();
        }
    }
}