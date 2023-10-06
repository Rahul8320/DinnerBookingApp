using DinnerBooking.Application.Common;
using DinnerBooking.Application.Dtos;
using ErrorOr;

namespace DinnerBooking.Application.Services.Interfaces
{
    public interface IAuthService
    {
        ErrorOr<ServiceResult> Register(RegisterRequestDto request);
        ErrorOr<ServiceResult> Login(LoginRequestDto request);
    }
}