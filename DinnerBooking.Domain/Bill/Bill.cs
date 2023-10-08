using DinnerBooking.Domain.Bill.ValueObjects;
using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Dinner.ValueObjects;
using DinnerBooking.Domain.Guest.ValueObjects;
using DinnerBooking.Domain.Host.ValueObjects;

namespace DinnerBooking.Domain.Bill;

public sealed class Bill : AggregateRoot<BillId>
{
    public Price Price { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId billId,
        Price price,
        HostId hostId,
        DinnerId dinnerId,
        GuestId guestId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(billId)
    {
        Price = price;
        HostId = hostId;
        DinnerId = dinnerId;
        GuestId = guestId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(
        HostId hostId,
        DinnerId dinnerId,
        GuestId guestId,
        decimal price,
        string currency)
    {
        return new Bill(
            BillId.CreateUnique(),
            Price.Create(price, currency),
            hostId,
            dinnerId,
            guestId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
