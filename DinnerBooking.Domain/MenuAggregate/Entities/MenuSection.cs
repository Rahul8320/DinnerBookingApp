using DinnerBooking.Domain.Common.Models;
using DinnerBooking.Domain.MenuAggregate.ValueObjects;

namespace DinnerBooking.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = [];
    public string Name { get; }
    public string Description { get; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public static MenuSection Create(string name, string description, List<MenuItem>? items)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description, items ?? []);
    }
}
