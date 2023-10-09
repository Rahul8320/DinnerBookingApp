using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.MenuAggregate.ValueObjects;

public class MenuItemId : ValueObject
{
    private Guid Value { get; }
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
