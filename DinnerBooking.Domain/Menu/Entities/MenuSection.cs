using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.Menu.ValueObjects;

namespace DinnerBooking.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = [];
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(string name, string description)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}
