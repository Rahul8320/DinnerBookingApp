using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.BillAggregate.ValueObjects;

public sealed class BillId : ValueObject
{
    private Guid Value { get; }
    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
