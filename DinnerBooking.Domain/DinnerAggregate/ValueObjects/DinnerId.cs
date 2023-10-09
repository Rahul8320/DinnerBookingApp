using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.DinnerAggregate.ValueObjects;

public class DinnerId : ValueObject
{
    private Guid Value { get; }
    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}