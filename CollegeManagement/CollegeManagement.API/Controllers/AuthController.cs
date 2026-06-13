using CollegeManagement.API.DTOs;
using CollegeManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterDto dto)
        {
            await _authService.Register(dto);

            return Ok("User Registered Successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDto dto)
        {
            var token =
                await _authService.Login(dto);

            return Ok(new
            {
                Token = token
            });
        }
    }
}
