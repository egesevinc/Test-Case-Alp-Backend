using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CaseAlp.Services;
using CaseAlp.Models;

namespace CaseAlp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result)
                {
                    return Ok(new { Message = "Registration successful" });
                }
                else
                {
                    return BadRequest(new { Message = "Registration failed" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var result = await _userService.AuthenticateUserAsync(model);

                if (result)
                {
                    return Ok(new { Message = "Login successful" });
                }
                else
                {
                    return Unauthorized(new { Message = "Invalid credentials" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }
    }
}
