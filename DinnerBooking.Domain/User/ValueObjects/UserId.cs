using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    private Guid Value { get; }
    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}