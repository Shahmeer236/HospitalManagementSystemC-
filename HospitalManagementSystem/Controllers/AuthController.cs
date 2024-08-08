using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Dtos.Auth;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Services.Interface;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public AuthController(IUserServices userServices, IConfiguration configuration)
        {
            _userServices = userServices;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userServices.GetUserByEmailAsync(loginRequest.Email);

            if (user == null || user.Password != loginRequest.Password)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role) // Ensure role is not null here
            };

            var token = JwtHelper.GenerateToken(
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims);

            return Ok(new LoginResponse { Token = token, Role = user.Role });
        }
    }
}
