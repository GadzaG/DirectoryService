using DirectoryService.Domain.Models;
using DirectoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("location");

        builder.HasKey(location => location.Id).HasName("pk_location");
        
        builder.Property(location => location.Id).HasColumnName("id");
        
        builder.OwnsOne(location => location.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOCATION_NAME_LENGTH)
                .HasColumnName("name");
        });
        builder.Navigation(location => location.Name).IsRequired();

        builder.OwnsOne(location => location.Address, addressBuilder =>
        {
            addressBuilder.Property(address => address.Country)
                .IsRequired()
                .HasColumnName("country");

            addressBuilder.Property(address => address.Region)
                .IsRequired()
                .HasColumnName("region");

            addressBuilder.Property(address => address.City)
                .IsRequired()
                .HasColumnName("city");

            addressBuilder.Property(address => address.Street)
                .IsRequired()
                .HasColumnName("street");

            addressBuilder.Property(address => address.House)
                .IsRequired()
                .HasColumnName("house");

            addressBuilder.Property(address => address.PostalCode)
                .HasColumnName("postal_code");
        });
        builder.Navigation(location => location.Address).IsRequired();

        builder.OwnsOne(location => location.Timezone, addressBuilder =>
        {
            addressBuilder.Property(timezone => timezone.Value)
                .IsRequired()
                .HasColumnName("timezone");
        });
        builder.Navigation(location => location.Timezone).IsRequired();
    }
}