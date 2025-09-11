using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record Address
{
    public string Country { get; private set; }

    public string City { get; private set; }

    public string Region { get; private set; }

    public string Street { get; private set; }

    public string House { get; private set; }

    public string? PostalCode { get; private set; }

    private Address(string country, string city, string region, string street, string house, string postalCode)
    {
        Country = country;
        City = city;
        Region = region;
        Street = street;
        House = house;
        PostalCode = postalCode;
    }

    public static Result<Address, Error> Create(
        string country,
        string city,
        string region,
        string street,
        string houseNumber,
        string? postalCode)
    {
        if (string.IsNullOrEmpty(country))
            return Errors.General.ValueIsRequired(nameof(Country));
        if (string.IsNullOrEmpty(city))
            return Errors.General.ValueIsRequired(nameof(City));
        if (string.IsNullOrEmpty(region))
            return Errors.General.ValueIsRequired(nameof(Region));
        if (string.IsNullOrEmpty(street))
            return Errors.General.ValueIsRequired(nameof(Street));
        if (string.IsNullOrEmpty(houseNumber))
            return Errors.General.ValueIsRequired(nameof(houseNumber));

        return new Address(country, city, region, street, houseNumber, postalCode);
    }
}