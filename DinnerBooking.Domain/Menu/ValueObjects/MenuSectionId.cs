using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    private Guid Value { get; }
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}