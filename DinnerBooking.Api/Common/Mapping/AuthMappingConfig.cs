using DinnerBooking.Application.Authentication.Commands.Register;
using DinnerBooking.Application.Authentication.Queries.Login;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Contracts.Authentication;

using Mapster;

namespace DinnerBooking.Api.Common.Mapping;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthResponseDto, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.ToString());
    }
}
