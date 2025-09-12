using System.Data;

namespace DirectoryService.Application.Abstractions.Database;

public interface IUnitOfWork
{
    Task<IDbTransaction> BeginTransactionAsync(CancellationToken ct = default);

    Task SaveChangesAsync(CancellationToken ct = default);
}