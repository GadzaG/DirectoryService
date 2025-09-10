using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models;

public class DepartmentLocation : EntityBase
{
    private DepartmentLocation() { }

    private DepartmentLocation(Guid id, DateTime createdAt, Guid departmentId, Guid locationId)
        : base(id, createdAt)
    {
        DepartmentId = departmentId;
        LocationId = locationId;
    }

    public Guid DepartmentId { get; private set; }

    public Guid LocationId { get; private set; }

    public static Result<DepartmentLocation, Error> Create(Guid departmentId, Guid locationId)
    {
        return new DepartmentLocation(Guid.NewGuid(), DateTime.UtcNow, departmentId, locationId);
    }
}