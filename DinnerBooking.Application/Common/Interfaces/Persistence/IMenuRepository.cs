using DinnerBooking.Domain.MenuAggregate;

namespace DinnerBooking.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}
