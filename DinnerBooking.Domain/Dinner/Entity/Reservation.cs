using DinnerBooking.Domain.Bill.ValueObjects;
using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Dinner.Common;
using DinnerBooking.Domain.Dinner.ValueObjects;
using DinnerBooking.Domain.Guest.ValueObjects;

namespace DinnerBooking.Domain.Dinner.Entity;

public sealed class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public ReservationStatusType ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        ReservationStatusType reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        DateTime? arrivalDateTime = null) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        int guestCount,
        ReservationStatusType reservationStatus,
        GuestId guestId,
        BillId billId)
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestCount,
            reservationStatus,
            guestId,
            billId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
