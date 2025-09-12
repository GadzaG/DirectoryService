using DirectoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_position");

        builder.HasKey(dp => dp.Id).HasName("pk_department_position");

        builder.Property(dp => dp.Id).HasColumnName("id");
        
        builder.Property(dp => dp.DepartmentId).IsRequired().HasColumnName("department_id");
        builder.Property(dp => dp.PositionId).IsRequired().HasColumnName("position_id");

        builder.HasIndex(dp => new { dp.DepartmentId, dp.PositionId })
            .IsUnique();

        builder.HasOne<Position>()
            .WithMany()
            .HasForeignKey(dp => dp.PositionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}