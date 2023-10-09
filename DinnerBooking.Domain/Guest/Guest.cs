using DinnerBooking.Domain.Bill.ValueObjects;
using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Common.ValueObjects;
using DinnerBooking.Domain.Dinner.ValueObjects;
using DinnerBooking.Domain.Guest.Entity;
using DinnerBooking.Domain.Guest.ValueObjects;
using DinnerBooking.Domain.MenuReview.ValueObjects;
using DinnerBooking.Domain.User.ValueObjects;

namespace DinnerBooking.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = [];
    private readonly List<DinnerId> _pastDinnerIds = [];
    private readonly List<DinnerId> _pendingDinnerIds = [];
    private readonly List<BillId> _billIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];
    private readonly List<RatingEntity> _ratings = [];
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<RatingEntity> Ratings => _ratings.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId
    )
    {
        return new Guest(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            AverageRating.CreateNew(),
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
