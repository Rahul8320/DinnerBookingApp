using DinnerBooking.Application.Common.Interfaces.Auth;
using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Application.Dtos;
using ErrorOr;
using MediatR;
using DinnerBooking.Domain.Common.Errors;
using AutoMapper;
using DinnerBooking.Domain.UserAggregate;


namespace DinnerBooking.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResponseDto>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthResponseDto>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //! TODO: (To be deleted) For disable the async warning
        await Task.CompletedTask;
        // 1. Validate the user does not exists
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create User (generate unique ID) & Persist to DB
        var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);
        _userRepository.AddUser(user);

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
