using DinnerBooking.Application.Dtos;

namespace DinnerBooking.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserDto userDto);
    }
}