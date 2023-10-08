using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Common.ValueObjects;
using DinnerBooking.Domain.Dinner.ValueObjects;
using DinnerBooking.Domain.Host.ValueObjects;
using DinnerBooking.Domain.Menu.Entities;
using DinnerBooking.Domain.Menu.ValueObjects;
using DinnerBooking.Domain.MenuReview.ValueObjects;

namespace DinnerBooking.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreateDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Menu(MenuId menuId, string name, string description, AverageRating averageRating, HostId hostId, DateTime createdDateTime, DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreateDateTime = createdDateTime;
        UpdateDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new Menu(MenuId.CreateUnique(), name, description, AverageRating.CreateNew(), hostId, DateTime.UtcNow, DateTime.UtcNow);
    }
}