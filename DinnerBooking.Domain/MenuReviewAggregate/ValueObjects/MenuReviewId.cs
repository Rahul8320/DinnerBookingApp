using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.MenuReviewAggregate.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }
    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}