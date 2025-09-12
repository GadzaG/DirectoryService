using DirectoryService.Domain.Models;
using DirectoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgres.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("department");

        builder.HasKey(department => department.Id).HasName("pk_department");
        
        builder.Property(department => department.Id).HasColumnName("id");

        builder.OwnsOne(department => department.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_DEPARTMENT_NAME_LENGTH)
                .HasColumnName("name");
        });
        builder.Navigation(department => department.Name).IsRequired();

        builder.OwnsOne(department => department.Identifier, identifierBuilder =>
        {
            identifierBuilder.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_IDENTIFIER_NAME_LENGTH)
                .HasColumnName("identifier");
        });
        builder.Navigation(department => department.Identifier).IsRequired();

        builder.OwnsOne(department => department.Path, pathBuilder =>
        {
            pathBuilder.Property(n => n.Value)
                .IsRequired()
                .HasColumnName("path");
        });
        builder.Navigation(department => department.Path).IsRequired();

        builder.Property(department => department.Depth).IsRequired();

        builder
            .HasOne(d => d.Parent)
            .WithMany(d => d.Children)
            .HasForeignKey("parent_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(d => d.DepartmentPositions)
            .WithOne()
            .HasForeignKey(dp => dp.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(d => d.DepartmentLocations)
            .WithOne()
            .HasForeignKey(dl => dl.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}