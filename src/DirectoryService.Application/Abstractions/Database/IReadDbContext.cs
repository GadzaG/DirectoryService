using DirectoryService.Domain.Models;

namespace DirectoryService.Application.Abstractions.Database;

public interface IReadDbContext
{
    IQueryable<Department> DepartmentsQueryable { get; }

    IQueryable<Location> LocationsQueryable { get; }

    IQueryable<Position> PositionsQueryable { get; }
}