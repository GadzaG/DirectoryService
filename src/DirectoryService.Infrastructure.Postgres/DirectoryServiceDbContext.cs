using DirectoryService.Application.Abstractions.Database;
using DirectoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DirectoryService.Infrastructure.Postgres;


 
public class DirectoryServiceDbContext(IOptions<PostgresOptions> postgresOptions) : DbContext, IReadDbContext
{
    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Position> Positions => Set<Position>();

    public IQueryable<Department> DepartmentsQueryable => Departments.AsNoTracking();

    public IQueryable<Location> LocationsQueryable => Locations.AsNoTracking();

    public IQueryable<Position> PositionsQueryable => Positions.AsNoTracking();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiceDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(postgresOptions.Value.GetConnectionString() )
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }

    private static ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => builder.AddConsole());
}

/*public class DirectoryServiceDbContext() : DbContext, IReadDbContext
{
    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<Position> Positions => Set<Position>();

    public IQueryable<Department> DepartmentsQueryable => Departments.AsNoTracking();

    public IQueryable<Location> LocationsQueryable => Locations.AsNoTracking();

    public IQueryable<Position> PositionsQueryable => Positions.AsNoTracking();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiceDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=4001;Database=directory_service_db;Username=postgres;Password=postgres;")
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }

    private static ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => builder.AddConsole());
}*/