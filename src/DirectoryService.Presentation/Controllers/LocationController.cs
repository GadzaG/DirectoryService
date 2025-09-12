using DirectoryService.Application.Locations.Commands.CreateLocation;
using DirectoryService.Domain.Shared;
using DirectoryService.Presentation.Extensions;
using DirectoryService.Presentation.Requests.Locations;
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
        var result = await handler.Handle(request.ToCommand(), ct);
        return result.IsFailure ? result.Error.ToResponse() : Ok(Envelope.Ok(result.Value));
    }
}