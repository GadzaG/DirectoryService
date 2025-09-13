using CSharpFunctionalExtensions;
using DirectoryService.Application.Abstractions.Core;
using DirectoryService.Application.Abstractions.Database;
using DirectoryService.Contracts.Dtos;
using DirectoryService.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Application.Locations.Queries.GetLocations;


public class GetLocationsHandler(ILogger<GetLocationsQuery> logger, IReadDbContext context)
    : IQueryHandler<Result<List<LocationDto>, Error>, GetLocationsQuery>
{
    public async Task<Result<List<LocationDto>, Error>> Handle(GetLocationsQuery request, CancellationToken ct = default)
    {
        return await context.LocationsQueryable
            .Select(l => new LocationDto(
                l.Id,
                l.Name.Value,
                new AddressDto(
                    l.Address.Country,
                    l.Address.City,
                    l.Address.Region,
                    l.Address.Street,
                    l.Address.House,
                    l.Address.PostalCode),
                l.Timezone.Value))
            .ToListAsync(ct);
    }
}