using DinnerBooking.Application.Dtos;
using ErrorOr;
using MediatR;

namespace DinnerBooking.Application.Authentication.Queries.Login;

public record LoginQuery
(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthResponseDto>>;

