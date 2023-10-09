using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Domain.HostAggregate.ValueObjects;
using DinnerBooking.Domain.MenuAggregate;
using DinnerBooking.Domain.MenuAggregate.Entities;

using ErrorOr;

using MediatR;

namespace DinnerBooking.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // ! TODO: delete this 
        await Task.CompletedTask;
        // Create Menu
        var menu = Menu.Create(
            name: request.Name,
            description: request.Description,
            hostId: HostId.Create(request.HostId),
            sections: request.Sections.ConvertAll(
                section => MenuSection.Create(
                    name: section.Name,
                    description: section.Description,
                    items: section.Items.ConvertAll(item => MenuItem.Create(
                        name: item.Name,
                        description: item.Description)
                    )
                )
            )
        );
        // Persist Menu
        _menuRepository.Add(menu);

        // Return Menu
        return menu;
    }
}
