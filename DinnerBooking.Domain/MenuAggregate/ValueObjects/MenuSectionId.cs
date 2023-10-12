using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// Represent the menu section id value object.
/// </summary>
public sealed class MenuSectionId : ValueObject
{
    /// <summary>
    /// Gets the menu section id value
    /// </summary>
    public Guid Value { get; }
    /// <summary>
    /// Creates the new instance of menu section id
    /// </summary>
    /// <param name="value">Value of the menu section id</param>
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates the new instance of menu section id
    /// </summary>
    /// <returns>Returns the menu item id instance</returns>
    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
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