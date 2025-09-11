using DirectoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_location");

        builder.HasKey(dl => dl.Id).HasName("pk_department_location");
        builder.Property(dl => dl.Id).HasColumnName("id");

        builder.Property(dl => dl.DepartmentId).IsRequired().HasColumnName("department_id");
        builder.Property(dl => dl.LocationId).IsRequired().HasColumnName("location_id");

        builder.HasIndex(dl => new { dl.DepartmentId, dl.LocationId })
            .IsUnique();

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(dl => dl.LocationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}