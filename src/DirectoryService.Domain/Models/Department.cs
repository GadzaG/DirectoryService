using CSharpFunctionalExtensions;
using DirectoryService.Domain.Models.ValueObjects;
using DirectoryService.Domain.Shared;
using Path = DirectoryService.Domain.Models.ValueObjects.Path;


namespace DirectoryService.Domain.Models;

public class Department : EntityBase
{
    private readonly List<Department> _children = [];

    private readonly List<DepartmentPosition> _departmentPositions = [];

    private readonly List<DepartmentLocation> _departmentLocations = [];

    private Department() // ef
    {
    }

    private Department(
        Guid id,
        DateTime createdAt,
        DepartmentName name,
        Identifier identifier,
        Path path,
        short depth,
        Department? parent)
        : base(id, createdAt)
    {
        Name = name;
        Identifier = identifier;
        Path = path;
        Depth = depth;
        Parent = parent;
    }

    public Department? Parent { get; set; }

    public IReadOnlyList<Department> Children => _children;

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;

    public DepartmentName Name { get; private set; }

    public Identifier Identifier { get; private set; }

    public Path Path { get; private set; }

    public short Depth { get; private set; }

    public static Result<Department, Error> Create(
        DepartmentName name,
        Identifier identifier,
        Department? parent = null)
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.Now;

        var path = parent is null
            ? Path.Create(identifier.Value)
            : Path.Create(parent.Path.Value, identifier.Value);

        if (path.IsFailure)
            return path.Error;

        short depth = (short)(parent?.Depth + 1 ?? 0);

        return new Department(id, createdAt, name, identifier, path.Value, depth, parent);
    }
}