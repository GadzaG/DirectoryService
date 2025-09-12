using DirectoryService.Domain.Models;
using DirectoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("position");

        builder.HasKey(position => position.Id).HasName("pk_position");
        
        builder.Property(position => position.Id).HasColumnName("id");

        builder.OwnsOne(position => position.Name, nameBuilder =>
        {
            nameBuilder.Property(positionName => positionName.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_POSITION_NAME_LENGTH)
                .HasColumnName("name");
        });
        builder.Navigation(position => position.Name).IsRequired();

        builder.OwnsOne(position => position.Description, descriptionBuilder =>
        {
            descriptionBuilder.Property(positionName => positionName.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_DESCRIPTION_NAME_LENGTH)
                .HasColumnName("description");
        });
        builder.Navigation(position => position.Description).IsRequired(false);
    }
}