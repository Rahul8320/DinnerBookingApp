using AutoMapper;
using DinnerBooking.Application.Common;
using DinnerBooking.Application.Common.Interfaces.Auth;
using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Application.Services.Auth.Interfaces;
using DinnerBooking.Domain.Common.Errors;
using DinnerBooking.Domain.Entities;
using ErrorOr;

namespace DinnerBooking.Application.Services.Auth
{
    public class AuthQueryService : IAuthQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public ErrorOr<ServiceResult> Login(LoginRequestDto request)
        {
            //! 1. Validate the user exists.
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //! 2. Validate the password is correct.
            if (!user.Password.Equals(request.Password))
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //! 3. Create JWT Token
            var mappedUserDto = _mapper.Map<UserDto>(user);
            var token = _jwtTokenGenerator.GenerateToken(mappedUserDto);

            AuthResponseDto result = new()
            {
                User = mappedUserDto,
                Token = token
            };

            return new ServiceResult<AuthResponseDto>()
            {
                IsSuccess = true,
                Message = "Login Successful",
                Data = result
            };
        }
    }
}