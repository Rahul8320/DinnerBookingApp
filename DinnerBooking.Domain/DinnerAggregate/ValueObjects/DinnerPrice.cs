using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerPrice : ValueObject
{
    private DinnerPrice(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public static DinnerPrice Create(decimal amount, string currency)
    {
        return new DinnerPrice(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
