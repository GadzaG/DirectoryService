using DirectoryService.Application.Abstractions.Core;
using DirectoryService.Application.Locations.Commands.CreateLocation;
using DirectoryService.Application.Locations.Queries.GetLocations;
using DirectoryService.Contracts.Dtos;
using DirectoryService.Contracts.Requests.Locations;
using DirectoryService.Domain.Shared;
using DirectoryService.Presentation.EndpointResults;
using DirectoryService.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController(ILogger<LocationController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<EndpointResult<Guid>> Create(
        [FromBody] CreateLocationRequest request,
        [FromServices] CreateLocationHandler handler,
        CancellationToken ct = default)
    {
        logger.LogInformation("Controller : createLocation");
        var createLocationCommand =
            new CreateLocationCommand(request.LocationName, request.AddressDto, request.Timezone);
        return await handler.Handle(createLocationCommand, ct);

        // return result.IsFailure ? result.Error.ToResponse() : Ok(Envelope.Ok(result.Value));
    }

    [HttpGet]
    public async Task<EndpointResult<List<LocationDto>>> GetAll(
        [FromServices] GetLocationsHandler handler,
        CancellationToken ct = default)
    {
        logger.LogInformation("Controller: GetAll");
        return await handler.Handle(new GetLocationsQuery(), ct);
    }
}