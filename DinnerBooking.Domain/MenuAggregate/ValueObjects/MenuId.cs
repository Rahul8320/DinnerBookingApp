using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.MenuAggregate.ValueObjects;

/// <summary>
/// Represents the value object fot MenuId
/// </summary>
public sealed class MenuId : ValueObject
{
    /// <summary>
    /// Gets Value of MenuId property
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Create a new class instance of MenuId
    /// </summary>
    /// <param name="value">The value of MenuId</param>
    private MenuId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Create a new MenuId instance
    /// </summary>
    /// <param name="value">The value of the menu id</param>
    /// <returns>Returns the created menu id object</returns>
    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }

    /// <summary>
    /// Create new unique menu id 
    /// </summary>
    /// <returns>Return the created menu id object</returns>
    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    /// <summary>
    /// Get the value of the menu id
    /// </summary>
    /// <returns>Return the value of menu id</returns>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}