using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Domain.MenuAggregate;

namespace DinnerBooking.Infrastructure.Persistence.Repository;

/// <summary>
/// Implements the IMenuRepository interface.
/// </summary>
public class MenuRepository : IMenuRepository
{
    /// <summary>
    /// Represents the application database context instance.
    /// </summary>
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the MenuRepository.
    /// </summary>
    /// <param name="context">Represent the database context.</param>
    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public void Add(Menu menu)
    {
        _context.Add(menu);
        _context.SaveChanges();
    }

}
