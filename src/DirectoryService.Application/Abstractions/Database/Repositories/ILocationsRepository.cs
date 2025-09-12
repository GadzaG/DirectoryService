using CSharpFunctionalExtensions;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Application.Abstractions.Database.Repositories;

public interface ILocationsRepository
{
    Task<Result<Guid, Error>> Add(Location location, CancellationToken ct = default);
}