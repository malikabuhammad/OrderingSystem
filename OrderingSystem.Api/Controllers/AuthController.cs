using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Application.DTOs.Auth;
using OrderingSystem.Application.Services;

namespace OrderingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _auth.LoginAsync(dto);
            if (result == null || !result.Success) return Unauthorized(result?.Message);

            return Ok(new { token = result.Token });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _auth.RegisterAsync(dto);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
