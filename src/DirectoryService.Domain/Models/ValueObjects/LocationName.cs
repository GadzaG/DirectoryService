using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record LocationName
{
    private LocationName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<LocationName, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired(nameof(LocationName));
        if(value.Length < Constants.MIN_LOCATION_NAME_LENGTH || value.Length > Constants.MAX_LOCATION_NAME_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(LocationName));
        return new LocationName(value);
    }
}