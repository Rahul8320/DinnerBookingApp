using AutoMapper;
using DinnerBooking.Application.Common.Interfaces.Auth;
using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Domain.Common.Errors;
using DinnerBooking.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace DinnerBooking.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResponseDto>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IMapper mapper)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<AuthResponseDto>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        //! TODO: (To be deleted) For disable the async warning
        await Task.CompletedTask;
        // 1. Validate the user exists.
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct.
        if (!user.Password.Equals(query.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. Create JWT Token
        var mappedUserDto = _mapper.Map<UserDto>(user);
        var token = _jwtTokenGenerator.GenerateToken(mappedUserDto);

        return new AuthResponseDto()
        {
            User = mappedUserDto,
            Token = token
        };
    }
}
