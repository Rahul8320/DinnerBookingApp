using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    private Rating(int value)
    {
        Value = value;
    }
    public double Value { get; private set; }

    public static Rating Create(int value)
    {
        return new Rating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
