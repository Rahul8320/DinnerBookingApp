using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.DinnerAggregate.Common;
using DinnerBooking.Domain.DinnerAggregate.Entity;
using DinnerBooking.Domain.DinnerAggregate.ValueObjects;
using DinnerBooking.Domain.HostAggregate.ValueObjects;
using DinnerBooking.Domain.MenuAggregate.ValueObjects;

namespace DinnerBooking.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = [];
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; }
    public DateTime? EndedDateTime { get; }
    public DinnerStatusType Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public DinnerPrice Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatusType status,
        bool isPublic,
        int maxGuests,
        DinnerPrice price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updateDateTime,
        DateTime? startedDateTime = null,
        DateTime? endedDateTime = null
    ) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updateDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatusType status,
        bool isPublic,
        int maxGuests,
        decimal priceAmount,
        string priceCurrency,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        string locationName,
        string locationAddress,
        decimal locationLatitude,
        decimal locationLongitude
    )
    {
        return new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            status,
            isPublic,
            maxGuests,
            DinnerPrice.Create(priceAmount, priceCurrency),
            hostId,
            menuId,
            imageUrl,
            Location.Create(
                locationName,
                locationAddress,
                locationLatitude,
                locationLongitude
            ),
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
