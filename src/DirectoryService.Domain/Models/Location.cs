using CSharpFunctionalExtensions;
using DirectoryService.Domain.Models.ValueObjects;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models;

public class Location : EntityBase
{
    private Location() //ef
    {
    }

    private Location(Guid id, DateTime createdAt, LocationName name, Address address, Timezone timezone)
        : base(id, createdAt)
    {
        Name = name;
        Address = address;
        Timezone = timezone;
    }

    public LocationName Name { get; private set; }

    public Address Address { get; private set; }

    public Timezone Timezone { get; private set; }

    public static Result<Location, Error> Create(LocationName name, Address address, Timezone timezone)
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        return new Location(id, createdAt, name, address, timezone);
    }

    public static Result<Location, Error> Create(LocationName name, Address address)
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var timezone = Timezone.Create(string.Concat('/', address.Country, address.City));
        if(timezone.IsFailure)
            return timezone.Error;
        return new Location(id, createdAt, name, address, timezone.Value);
    }
}