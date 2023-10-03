using DinnerBooking.Application.Common;
using DinnerBooking.Application.Dtos;

namespace DinnerBooking.Application.Services.Interfaces
{
    public interface IAuthService
    {
        ServiceResult Register(RegisterRequestDto request);
        ServiceResult Login(LoginRequestDto request);
    }
}