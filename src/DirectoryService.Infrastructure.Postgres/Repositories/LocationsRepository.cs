using CSharpFunctionalExtensions;
using DirectoryService.Application.Abstractions.Database.Repositories;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrastructure.Postgres.Repositories;

public class LocationsRepository(ILogger<LocationsRepository> logger, DirectoryServiceDbContext context)
    : ILocationsRepository
{
    public async Task<Result<Guid, Error>> Add(Location location, CancellationToken ct = default)
    {
        try
        {
            await context.Locations.AddAsync(location, ct);
            await context.SaveChangesAsync(ct);
            return location.Id;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error adding location {id} ", location.Id);
            return Errors.Infrastructure.UnknownException("Error adding location");
        }
    }
}