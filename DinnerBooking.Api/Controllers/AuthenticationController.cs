using DinnerBooking.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(request);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(request);
            }
            return BadRequest();
        }
    }
}