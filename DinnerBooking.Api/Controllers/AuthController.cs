using AutoMapper;
using DinnerBooking.Application.Common;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Application.Services.Auth.Interfaces;
using DinnerBooking.Application.Services.Interfaces;
using DinnerBooking.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IAuthCommandService _authCommandService;
        private readonly IAuthQueryService _authQueryService;
        private readonly IMapper _mapper;

        public AuthController(IAuthCommandService authCommandService, IAuthQueryService authQueryService, IMapper mapper)
        {
            _authCommandService = authCommandService;
            _authQueryService = authQueryService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var input = _mapper.Map<RegisterRequestDto>(request);
                ErrorOr<ServiceResult> authResult = _authCommandService.Register(input);

                return authResult.Match(Ok, Problem);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var input = _mapper.Map<LoginRequestDto>(request);
                ErrorOr<ServiceResult> authResult = _authQueryService.Login(input);

                return authResult.Match(Ok, Problem);
            }
            return BadRequest();
        }
    }
}