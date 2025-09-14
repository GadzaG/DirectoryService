namespace DirectoryService.Domain.Shared;

public record Error
{
    private const string SEPARATOR = "||";
    public string Code { get; }

    public string Message { get; }

    public ErrorType Type { get; }
    public string InvalidField { get; }

    private Error(
        string code,
        string message,
        ErrorType errorType,
        string? invalidField = default)
    {
        Code = code;
        Message = message;
        Type = errorType;
        InvalidField = invalidField ?? string.Empty;
    }

    public static Error Validation(string code, string message, string? validField = default)
        => new(code, message, ErrorType.VALIDATION, validField);

    public static Error NotFound(string code, string message)
        => new(code, message, ErrorType.NOT_FOUND);

    public static Error Failure(string code, string message)
        => new(code, message, ErrorType.FAILURE);

    public static Error Conflict(string code, string message)
        => new(code, message, ErrorType.CONFLICT);

    public string Serialize() => string.Join(SEPARATOR, Code, Message, Type);

    public static Error Deserialize(string serialized)
    {
        var parts = serialized.Split(SEPARATOR);

        if (parts.Length < 3)
            throw new ArgumentException("Invalid serialized format");

        if (Enum.TryParse<ErrorType>(parts[2], out var type) == false)
            throw new ArgumentException("Invalid serialized format");

        return new Error(parts[0], parts[1], type);
    }

    public ErrorList ToErrorList() => new([this]);
}

public enum ErrorType
{
    VALIDATION,
    NOT_FOUND,
    FAILURE,
    CONFLICT,
}