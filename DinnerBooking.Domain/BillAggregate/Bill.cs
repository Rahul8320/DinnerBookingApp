using DinnerBooking.Domain.BillAggregate.ValueObjects;
using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.DinnerAggregate.ValueObjects;
using DinnerBooking.Domain.GuestAggregate.ValueObjects;
using DinnerBooking.Domain.HostAggregate.ValueObjects;

namespace DinnerBooking.Domain.BillAggregate;

public sealed class Bill : AggregateRoot<BillId>
{
    public BillPrice Price { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Bill(
        BillId billId,
        BillPrice price,
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
            BillPrice.Create(price, currency),
            hostId,
            dinnerId,
            guestId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
