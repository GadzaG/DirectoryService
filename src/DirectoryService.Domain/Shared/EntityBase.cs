namespace DirectoryService.Domain.Shared;

public abstract class EntityBase
{
    protected EntityBase(Guid id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    protected EntityBase()
    {
    }

    public Guid Id { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public bool IsActive { get;  private set; } = true;

    public void Update(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }
}