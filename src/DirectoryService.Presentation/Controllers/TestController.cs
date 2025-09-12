using DirectoryService.Application.Abstractions.Database;
using DirectoryService.Domain.Models;
using DirectoryService.Domain.Models.ValueObjects;
using DirectoryService.Infrastructure.Postgres;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Presentation.Controllers;

public record CreateLocationRequest(
    string Name,
    string Country,
    string City,
    string Street,
    string Region,
    string House,
    string? PostalCode,
    string Timezone);

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Location>>> Get([FromServices] DirectoryServiceDbContext context)
    {
        var locations = await context.Locations.ToListAsync();
        return locations.Count == 0 ? NotFound() : Ok(locations);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateLocationRequest request, [FromServices] DirectoryServiceDbContext context)
    {
        try
        {
            var name = LocationName.Create(request.Name);
            if (name.IsFailure)
                return BadRequest(name.Error);
            var address = Address.Create(request.Country, request.City, request.Region, request.Street, request.House, request.PostalCode);
            if (address.IsFailure)
                return BadRequest(address.Error);
            var timezone = Timezone.Create(request.Timezone);
            if (timezone.IsFailure)
                return BadRequest(timezone.Error);
            var location = Location.Create(name.Value, address.Value, timezone.Value);
            if (location.IsFailure)
                return BadRequest(location.Error);
            await context.Locations.AddAsync(location.Value);
            await context.SaveChangesAsync();
            return Ok(location.Value.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

        /*var locName = LocationName.Create("test1");
        if (loc)
        var address = Address.Create(
            country: "Россия",
            city: "Москва",
            region: "Центральный федеральный округ",
            street: "Невский проспект",
            houseNumber: "12А",
            postalCode: "101000"
        );
        if (address.IsFailure)
            return BadRequest(address.Error);
        var timezone = Timezone.Create("Russia/Moscow");
        var newLocation = Location.Create(locName.Value, address.Value, timezone.Value);
        try
        {
            await context.Locations.AddAsync(newLocation.Value);
            await context.SaveChangesAsync();
            return Ok(newLocation.Value.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }*/
    }
}