using DinnerBooking.Application.Common;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Application.Services.Interfaces;

namespace DinnerBooking.Application.Services
{
    public class AuthService : IAuthService
    {
        public ServiceResult Login(LoginRequestDto request)
        {
            AuthResponseDto result = new()
            {
                Id = Guid.NewGuid(),
                FirstName = "first name",
                LastName = "last name",
                Email = request.Email,
                Token = "token"
            };

            return new ServiceResult<AuthResponseDto>()
            {
                IsSuccess = true,
                Message = "Login Successful",
                Data = result
            };
        }

        public ServiceResult Register(RegisterRequestDto request)
        {
            AuthResponseDto result = new()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Token = "token"
            };

            return new ServiceResult<AuthResponseDto>()
            {
                IsSuccess = true,
                Message = "Register Successful",
                Data = result
            };
        }
    }
}