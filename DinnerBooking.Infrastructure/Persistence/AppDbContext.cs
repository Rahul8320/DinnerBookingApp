using DinnerBooking.Domain.MenuAggregate;

using Microsoft.EntityFrameworkCore;

namespace DinnerBooking.Infrastructure.Persistence;

/// <summary>
/// Represents the database context for the application
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Creates a new instance of AppDbContext class
    /// </summary>
    /// <param name="options">Inject database context options using option pattern</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    /// <summary>
    /// Gets or sets the Menu database table.
    /// </summary>
    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
