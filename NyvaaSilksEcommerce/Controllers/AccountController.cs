using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NyvaaSilksEcommerce.Helpers;
using NyvaaSilksEcommerce.Models;
using NyvaaSilksEcommerce.Services;

namespace NyvaaSilksEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            bool result = await _userService.RegisterUserAsync(user);
            if (result)
            {
                return Ok(new { Message = "Registration successful!" });
            }
            return BadRequest("Error during registration.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userService.GetUserByEmailOrMobileAsync(loginModel.EmailOrMobile);
            if (user != null && BCrypt.Net.BCrypt.Verify(loginModel.Password, user.PasswordHash))
            {
                // Generate JWT token
                var token = JwtTokenHelper.GenerateJwtToken(user);
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid credentials.");
        }
    }
}
