using DinnerBooking.Domain.HostAggregate.ValueObjects;
using DinnerBooking.Domain.MenuAggregate;
using DinnerBooking.Domain.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DinnerBooking.Infrastructure.Persistence.Configurations;

/// <summary>
/// Represents the configuration for Menu Entity.
/// </summary>
public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    /// <summary>
    /// Configures the configuration
    /// </summary>
    /// <param name="builder">The builder object</param>
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        // configure menu tables.
        ConfigureMenusTables(builder);
    }

    /// <summary>
    /// Configurations for menus tables
    /// </summary>
    /// <param name="builder">The builder object</param>
    private void ConfigureMenusTables(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
          .ValueGeneratedNever()
          .HasConversion(
            id => id.Value,
            value => MenuId.Create(value)
          );

        builder.Property(m => m.Name).HasMaxLength(100);
        builder.Property(m => m.Description).HasMaxLength(100);
        builder.OwnsOne(m => m.AverageRating);
        builder.Property(m => m.HostId)
            .HasConversion(id => id.Value, value => HostId.Create(value));

    }
}
