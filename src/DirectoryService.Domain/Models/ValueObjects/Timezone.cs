using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record Timezone
{
    public string Value { get; private set; }

    private Timezone(string value)
    {
        Value = value;
    }

    public static Result<Timezone, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired(nameof(Timezone));

        try
        {
            _ = TimeZoneInfo.FindSystemTimeZoneById(value);
        }
        catch (TimeZoneNotFoundException)
        {
            return Errors.General.ValueIsInvalid(nameof(Timezone));
        }
        catch (InvalidTimeZoneException)
        {
            return Errors.General.ValueIsInvalid(nameof(Timezone));
        }

        return new Timezone(value);
    }
}