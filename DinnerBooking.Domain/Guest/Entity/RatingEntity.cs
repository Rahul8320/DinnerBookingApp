using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Common.ValueObjects;
using DinnerBooking.Domain.Dinner.ValueObjects;
using DinnerBooking.Domain.Guest.ValueObjects;
using DinnerBooking.Domain.Host.ValueObjects;

namespace DinnerBooking.Domain.Guest.Entity;

public sealed class RatingEntity : Entity<RatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public Rating Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private RatingEntity(
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

    public static RatingEntity Create(HostId hostId,
        DinnerId dinnerId,
        int rating
    )
    {
        return new RatingEntity(
            RatingId.CreateUnique(),
            hostId,
            dinnerId,
            Rating.Create(rating),
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
