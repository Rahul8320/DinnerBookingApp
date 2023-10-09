using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Common.ValueObjects;
using DinnerBooking.Domain.Dinner.ValueObjects;
using DinnerBooking.Domain.Host.ValueObjects;
using DinnerBooking.Domain.Menu.ValueObjects;
using DinnerBooking.Domain.User.ValueObjects;

namespace DinnerBooking.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<DinnerId> _DinnerIds = [];
    private readonly List<MenuId> _menuIds = [];
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _DinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId
    )
    {
        return new Host(
            HostId.CreateUnique(),
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
