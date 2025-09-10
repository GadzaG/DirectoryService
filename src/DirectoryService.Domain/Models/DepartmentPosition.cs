using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models;

public class DepartmentPosition : EntityBase
{
    private DepartmentPosition() { }

    private DepartmentPosition(Guid id, DateTime createdAt, Guid departmentId, Guid positionId)
        : base(id, createdAt)
    {
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public Guid DepartmentId { get; private set; }

    public Guid PositionId { get; private set; }

    public static Result<DepartmentPosition, Error> Create(Guid departmentId, Guid positionId)
    {
        return new DepartmentPosition(Guid.NewGuid(), DateTime.UtcNow, departmentId, positionId);
    }
}