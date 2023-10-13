using DinnerBooking.Domain.HostAggregate.ValueObjects;
using DinnerBooking.Domain.MenuAggregate;
using DinnerBooking.Domain.MenuAggregate.Entities;
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
    // configure menu table.
    ConfigureMenusTables(builder);

    // configure menu section table.
    ConfigureMenuSectionTables(builder);

    // configure dinner ids table.
    ConfigureDinnerIdsTable(builder);

    // configure menu review ids table.
    ConfigureMenuReviewIdsTable(builder);
  }

  /// <summary>
  /// Represents the configuration for dinner ids table.
  /// </summary>
  /// <param name="builder">The builder object.</param>
  private void ConfigureDinnerIdsTable(EntityTypeBuilder<Menu> builder)
  {
    builder.OwnsMany(m => m.DinnerIds, dib =>
    {
      dib.ToTable("MenuDinnerIds");

      dib.WithOwner().HasForeignKey("MenuId");

      dib.HasKey("Id");

      dib.Property(d => d.Value).HasColumnName("DinnerId").ValueGeneratedNever();
    });

    builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))?.SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  /// <summary>
  /// Represents the configuration for menu review ids table.
  /// </summary>
  /// <param name="builder">The builder object.</param>
  private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
  {
    builder.OwnsMany(m => m.MenuReviewIds, dib =>
    {
      dib.ToTable("MenuReviewIds");

      dib.WithOwner().HasForeignKey("MenuId");

      dib.HasKey("Id");

      dib.Property(d => d.Value).HasColumnName("ReviewId").ValueGeneratedNever();
    });

    builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))?.SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  /// <summary>
  /// Represents the configuration for menu section table.
  /// </summary>
  /// <param name="builder">The builder object that helps to create the table.</param>
  private void ConfigureMenuSectionTables(EntityTypeBuilder<Menu> builder)
  {
    builder.OwnsMany(m => m.Sections, sectionBuilder =>
    {
      sectionBuilder.ToTable("MenuSections");

      sectionBuilder.WithOwner().HasForeignKey("MenuId");

      sectionBuilder.HasKey("Id", "MenuId");

      sectionBuilder.Property(s => s.Id)
        .HasColumnName("MenuSectionId")
        .ValueGeneratedNever()
        .HasConversion(id => id.Value, value => MenuSectionId.Create(value));

      sectionBuilder.Property(s => s.Name).HasMaxLength(100);
      sectionBuilder.Property(s => s.Description).HasMaxLength(100);

      sectionBuilder.OwnsMany(s => s.Items, itemBuilder =>
      {
        itemBuilder.ToTable("MenuItems");

        itemBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

        itemBuilder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

        itemBuilder.Property(i => i.Id)
          .HasColumnName("MenuItemId")
          .ValueGeneratedNever()
          .HasConversion(id => id.Value, value => MenuItemId.Create(value));

        itemBuilder.Property(i => i.Name).HasMaxLength(100);
        itemBuilder.Property(i => i.Description).HasMaxLength(100);
      });

      sectionBuilder.Navigation(s => s.Items).Metadata.SetField("_items");
      sectionBuilder.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    });

    builder.Metadata.FindNavigation(nameof(Menu.Sections))?.SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  /// <summary>
  /// Represents the configuration for menus table.
  /// </summary>
  /// <param name="builder">The builder object that helps to create the table.</param>
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
