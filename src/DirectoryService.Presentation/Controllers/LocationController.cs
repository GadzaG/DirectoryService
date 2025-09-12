using DirectoryService.Application.Locations.Commands.CreateLocation;
using DirectoryService.Contracts.Requests.Locations;
using DirectoryService.Domain.Shared;
using DirectoryService.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presentation.Controllers;


[ApiController]
[Route("api/locations")]
public class LocationController(ILogger<LocationController> logger) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromBody] CreateLocationRequest request,
        [FromServices] CreateLocationHandler handler,
        CancellationToken ct = default)
    {
        logger.LogInformation("Controller : createLocation");
        var createLocationCommand = new CreateLocationCommand(request.LocationName, request.AddressDto, request.Timezone);
        var result = await handler.Handle(createLocationCommand, ct);
        return result.IsFailure ? result.Error.ToResponse() : Ok(Envelope.Ok(result.Value));
    }
}