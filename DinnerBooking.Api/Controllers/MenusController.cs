using DinnerBooking.Application.Menus.Commands.CreateMenu;
using DinnerBooking.Contracts.Menus;
using DinnerBooking.Domain.MenuAggregate;

using ErrorOr;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers;


[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public MenusController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        CreateMenuCommand? command = _mapper.Map<CreateMenuCommand>((request, hostId));

        ErrorOr<Menu> createMenuResult = await _mediator.Send(command);
        return Ok(request);
    }
}
