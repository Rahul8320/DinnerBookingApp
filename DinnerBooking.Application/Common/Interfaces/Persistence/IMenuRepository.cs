using DinnerBooking.Domain.MenuAggregate;

namespace DinnerBooking.Application.Common.Interfaces.Persistence;

/// <summary>
/// Represents the menu repository interface for managing the menu items.
/// </summary>
public interface IMenuRepository
{
    /// <summary>
    /// Adds a menu item to the database.
    /// </summary>
    /// <param name="menu">The menu item to be added to database.</param>
    void Add(Menu menu);
}
