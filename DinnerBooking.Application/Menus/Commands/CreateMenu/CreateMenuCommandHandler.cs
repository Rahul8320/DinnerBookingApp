using DinnerBooking.Domain.MenuAggregate;

using ErrorOr;

using MediatR;

namespace DinnerBooking.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Create Menu
        // Persist Menu
        // Return Menu
        return default!;
    }
}
