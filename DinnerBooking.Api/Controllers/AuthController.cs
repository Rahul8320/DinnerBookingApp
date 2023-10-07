using DinnerBooking.Application.Authentication.Commands.Register;
using DinnerBooking.Application.Authentication.Queries.Login;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers;
[Route("api/auth")]
public class AuthController : ApiController
{
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (ModelState.IsValid)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthResponseDto> authResult = await _mediator.Send(command);

            return authResult.Match(Ok, Problem);
        }
        return BadRequest();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (ModelState.IsValid)
        {
            var query = new LoginQuery(request.Email, request.Password);
            ErrorOr<AuthResponseDto> authResult = await _mediator.Send(query);

            return authResult.Match(Ok, Problem);
        }
        return BadRequest();
    }
}
