using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Common.ValueObjects;
using DinnerBooking.Domain.DinnerAggregate.ValueObjects;
using DinnerBooking.Domain.GuestAggregate.ValueObjects;
using DinnerBooking.Domain.HostAggregate.ValueObjects;

namespace DinnerBooking.Domain.GuestAggregate.Entity;

public sealed class GuestRating : Entity<RatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private GuestRating(
        RatingId ratingId,
        HostId hostId,
        DinnerId dinnerId,
        Rating rating,
        DateTime createdDateTime,
        DateTime updatedDateTime
    ) : base(ratingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static GuestRating Create(HostId hostId,
        DinnerId dinnerId,
        int rating
    )
    {
        return new GuestRating(
            RatingId.CreateUnique(),
            hostId,
            dinnerId,
            Rating.Create(rating),
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
