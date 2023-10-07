using DinnerBooking.Application.Common;
using DinnerBooking.Application.Dtos;
using ErrorOr;

namespace DinnerBooking.Application.Services.Interfaces
{
    public interface IAuthCommandService
    {
        ErrorOr<ServiceResult> Register(RegisterRequestDto request);
    }
}