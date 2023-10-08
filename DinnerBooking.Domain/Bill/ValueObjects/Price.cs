using DinnerBooking.Domain.Common.Models;

namespace DinnerBooking.Domain.Bill.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    public static Price Create(decimal amount, string currency)
    {
        return new Price(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
