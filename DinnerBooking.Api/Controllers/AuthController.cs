using AutoMapper;
using DinnerBooking.Application.Common;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Application.Services.Interfaces;
using DinnerBooking.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var input = _mapper.Map<RegisterRequestDto>(request);
                ErrorOr<ServiceResult> authResult = _authService.Register(input);

                return authResult.MatchFirst(
                    Ok,
                    firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
                );
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var input = _mapper.Map<LoginRequestDto>(request);
                ErrorOr<ServiceResult> authResult = _authService.Login(input);

                return authResult.MatchFirst(
                    Ok,
                    firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
                 );
            }
            return BadRequest();
        }
    }
}