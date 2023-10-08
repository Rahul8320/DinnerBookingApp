using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    private Guid Value { get; }
    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}