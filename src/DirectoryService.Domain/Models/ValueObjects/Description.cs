using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record Description
{
    public string Value { get; private set; }

    private Description(string value)
    {
        Value = value;
    }

    public static Result<Description, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired(nameof(Description));
        if (value.Length > Constants.MAX_DESCRIPTION_NAME_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(LocationName));
        return new Description(value);
    }
}