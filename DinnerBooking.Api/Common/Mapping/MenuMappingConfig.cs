using DinnerBooking.Application.Menus.Commands.CreateMenu;
using DinnerBooking.Contracts.Menus;

using Mapster;

namespace DinnerBooking.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);
    }
}
