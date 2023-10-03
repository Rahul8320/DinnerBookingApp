using DinnerBooking.Application.Common;
using DinnerBooking.Application.Common.Interfaces.Auth;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Application.Services.Interfaces;

namespace DinnerBooking.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

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
            //! Check if user already exists

            //! Create User (generate unique ID)

            //! Create JWT Token
            var userId = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(userId, request.FirstName, request.LastName);

            AuthResponseDto result = new()
            {
                Id = userId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Token = token
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