using CSharpFunctionalExtensions;
using DirectoryService.Domain.Models.ValueObjects;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models;

public class Position : EntityBase
{
    private Position() //ef
    {
    }

    private Position(Guid id, DateTime createdAt, PositionName name, Description? description = null)
        : base(id, createdAt)
    {
        Name = name;
        Description = description;
    }

    public PositionName Name { get; private set; }

    public Description? Description { get; private set; }

    public static Result<Position, Error> Create(PositionName name, Description? description = null)
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        return new Position(id, createdAt, name, description);
    }
}