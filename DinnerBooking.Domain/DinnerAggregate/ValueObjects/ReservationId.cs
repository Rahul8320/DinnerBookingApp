using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.DinnerAggregate.ValueObjects;

public sealed class ReservationId : ValueObject
{
    private Guid Value { get; }
    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
