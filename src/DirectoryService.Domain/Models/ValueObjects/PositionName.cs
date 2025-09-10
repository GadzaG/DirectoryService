using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record PositionName
{
    private PositionName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<PositionName, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired(nameof(PositionName));
        if(value.Length < Constants.MIN_POSITION_NAME_LENGTH || value.Length > Constants.MIN_POSITION_NAME_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(PositionName));
        return new PositionName(value);
    }
}