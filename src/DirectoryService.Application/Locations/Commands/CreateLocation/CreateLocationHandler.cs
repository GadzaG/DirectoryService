using CSharpFunctionalExtensions;
using DirectoryService.Application.Abstractions.Core;
using DirectoryService.Application.Abstractions.Database.Repositories;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Models.ValueObjects;
using DirectoryService.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Application.Locations.Commands.CreateLocation;

public class CreateLocationHandler(ILogger<CreateLocationHandler> logger, ILocationsRepository repository) : ICommandHandler<Guid, CreateLocationCommand>
{
    public async Task<Result<Guid, ErrorList>> Handle(CreateLocationCommand command, CancellationToken ct = default)
    {
        var locationName = LocationName.Create(command.Name);
        if (locationName.IsFailure)
            return locationName.Error.ToErrorList();

        var locationAddress = Address.Create(
            command.Address.Country,
            command.Address.City,
            command.Address.Region,
            command.Address.Street,
            command.Address.House,
            command.Address.PostalCode);
        if (locationAddress.IsFailure)
            return locationAddress.Error.ToErrorList();

        var locationTimezone = Timezone.Create(command.Timezone);
        if (locationTimezone.IsFailure)
            return locationTimezone.Error.ToErrorList();

        var location = Location.Create(locationName.Value, locationAddress.Value, locationTimezone.Value);
        var addLocation = await repository.Add(location.Value, ct);
        if (addLocation.IsFailure)
            return addLocation.Error.ToErrorList();
        return location.Value.Id;
    }
}