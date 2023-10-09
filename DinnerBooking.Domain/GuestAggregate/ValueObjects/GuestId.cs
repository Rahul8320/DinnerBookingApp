using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : ValueObject
{
    private Guid Value { get; }
    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new GuestId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
