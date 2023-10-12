using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Common.ValueObjects;
using DinnerBooking.Domain.DinnerAggregate.ValueObjects;
using DinnerBooking.Domain.HostAggregate.ValueObjects;
using DinnerBooking.Domain.MenuAggregate.Entities;
using DinnerBooking.Domain.MenuAggregate.ValueObjects;
using DinnerBooking.Domain.MenuReviewAggregate.ValueObjects;

namespace DinnerBooking.Domain.MenuAggregate;

/// <summary>
/// Represents the Menu entity.
/// </summary>
public sealed class Menu : AggregateRoot<MenuId>
{
    /// <summary>
    /// Readonly list of menu sections.
    /// </summary>
    private readonly List<MenuSection> _sections = [];
    /// <summary>
    /// Readonly list of dinner ids.
    /// </summary>
    private readonly List<DinnerId> _dinnerIds = [];
    /// <summary>
    /// Readonly list of menu review ids.
    /// </summary>
    private readonly List<MenuReviewId> _menuReviewIds = [];
    /// <summary>
    /// Gets the name of menu entity.
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// Gets the description of the menu entity.
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// Gets the average rating of the menu entity.
    /// </summary>
    public AverageRating AverageRating { get; }
    /// <summary>
    /// Represents the list of menu sections.
    /// </summary>
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    /// <summary>
    /// Gets the Host id of Menu entity.
    /// </summary>
    public HostId HostId { get; }
    /// <summary>
    /// Represents the list of dinner ids.
    /// </summary>
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    /// <summary>
    /// Represents the list of menu review ids.
    /// </summary>
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    /// <summary>
    /// Gets the created date time of menu entity.
    /// </summary>
    public DateTime CreatedDateTime { get; }
    /// <summary>
    /// Gets the updated date time of menu entity.
    /// </summary>
    public DateTime UpdatedDateTime { get; }

    /// <summary>
    /// Create an new instance of Menu entity.
    /// </summary>
    /// <param name="menuId">The menu id of new instance of menu entity</param>
    /// <param name="name">The menu name of new instance of menu entity</param>
    /// <param name="description">The menu description of new instance of menu entity</param>
    /// <param name="averageRating">The menu average rating of new instance of menu entity</param>
    /// <param name="hostId">The menu host id of new instance of menu entity</param>
    /// <param name="createdDateTime">The menu created date time of new instance of menu entity</param>
    /// <param name="updatedDateTime">The menu updated date time of new instance of menu entity</param>
    /// <param name="sections">The menu sections of new instance of menu entity</param>
    private Menu(
        MenuId menuId,
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        List<MenuSection> sections) : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        _sections = sections;
    }

    /// <summary>
    /// Create a new menu entity.
    /// </summary>
    /// <param name="name">The name of the new menu entity</param>
    /// <param name="description">The description of the new menu entity</param>
    /// <param name="hostId">The host id of the new menu entity</param>
    /// <param name="sections">The sections of the new menu entity</param>
    /// <returns></returns>
    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            AverageRating.CreateNew(),
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow,
            sections ?? []
        );
    }
}