using DinnerBooking.Application.Authentication.Commands.Register;
using DinnerBooking.Application.Authentication.Queries.Login;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers;

[Route("api/auth")]
public class AuthController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (ModelState.IsValid)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthResponseDto> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                Problem
            );
        }
        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (ModelState.IsValid)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthResponseDto> authResult = await _mediator.Send(query);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                Problem
            );
        }
        return BadRequest();
    }
}
