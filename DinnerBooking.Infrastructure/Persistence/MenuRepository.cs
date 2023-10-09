using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Domain.MenuAggregate;

namespace DinnerBooking.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = [];
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }

}
