using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Common.ValueObjects;
using DinnerBooking.Domain.DinnerAggregate.ValueObjects;
using DinnerBooking.Domain.HostAggregate.ValueObjects;
using DinnerBooking.Domain.MenuAggregate.ValueObjects;
using DinnerBooking.Domain.UserAggregate.ValueObjects;

namespace DinnerBooking.Domain.HostAggregate;

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
