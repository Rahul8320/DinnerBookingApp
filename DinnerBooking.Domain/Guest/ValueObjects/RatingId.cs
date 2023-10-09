using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.Guest.ValueObjects;

public sealed class RatingId : ValueObject
{
    private Guid Value { get; }
    private RatingId(Guid value)
    {
        Value = value;
    }

    public static RatingId CreateUnique()
    {
        return new RatingId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
