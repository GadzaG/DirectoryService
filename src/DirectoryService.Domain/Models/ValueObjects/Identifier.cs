using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record Identifier
{
    public string Value { get; private set; }

    private Identifier(string value)
    {
        Value = value;
    }

    public static Result<Identifier, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired(nameof(Identifier));
        if(value.Length < Constants.MIN_IDENTIFIER_NAME_LENGTH || value.Length > Constants.MAX_IDENTIFIER_NAME_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(Identifier));
        if (!Regex.IsMatch(value, @"^[A-Za-z]+$"))
            return Errors.General.ValueIsInvalid(nameof(Identifier));
        return new Identifier(value);
    }
}