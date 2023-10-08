using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.Menu.ValueObjects;

public sealed class MenuId : ValueObject
{
    private Guid Value { get; }
    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}