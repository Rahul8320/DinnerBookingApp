using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// Represents the menu item id value object.
/// </summary>
public class MenuItemId : ValueObject
{
    /// <summary>
    /// Gets value of the menu item id
    /// </summary>
    public Guid Value { get; }
    /// <summary>
    /// Creates new instance of the menu item id.
    /// </summary>
    /// <param name="value">The value of the menu item id.</param>
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates new instance of the menu item id.
    /// </summary>
    /// <returns>Returns the menu item id.</returns>
    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    /// <summary>
    /// Get equality components
    /// </summary>
    /// <returns>IEnumerable of value.</returns>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
