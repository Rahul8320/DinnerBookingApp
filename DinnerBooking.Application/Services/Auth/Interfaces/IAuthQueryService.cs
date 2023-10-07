using DinnerBooking.Application.Common;
using DinnerBooking.Application.Dtos;
using ErrorOr;

namespace DinnerBooking.Application.Services.Auth.Interfaces
{
    public interface IAuthQueryService
    {
        ErrorOr<ServiceResult> Login(LoginRequestDto request);

    }
}