using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.BillAggregate.ValueObjects;

public sealed class BillPrice : ValueObject
{
    private BillPrice(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public static BillPrice Create(decimal amount, string currency)
    {
        return new BillPrice(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
