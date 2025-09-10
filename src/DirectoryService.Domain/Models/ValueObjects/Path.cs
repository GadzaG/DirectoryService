using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record Path
{
    private Path(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Path, Error> Create(params string[] segments)
    {
        if (segments.Length == 0 || segments.Any(string.IsNullOrWhiteSpace))
            return Errors.General.ValueIsInvalid(nameof(Path));

        string newPathValue = string.Join(Constants.PATH_SEPARATOR, segments);
        return new Path(newPathValue);
    }

}