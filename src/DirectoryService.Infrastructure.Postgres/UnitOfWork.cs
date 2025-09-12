using System.Data;
using DirectoryService.Application.Abstractions.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace DirectoryService.Infrastructure.Postgres;

public class UnitOfWork(DirectoryServiceDbContext context) : IUnitOfWork
{
    public async Task<IDbTransaction> BeginTransactionAsync(
        CancellationToken ct = default)
    {
        var transaction = await context.Database.BeginTransactionAsync(ct);
        return transaction.GetDbTransaction();
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await context.SaveChangesAsync(ct);
    }
}