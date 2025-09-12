namespace DirectoryService.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null, string? fieldName = null)
        {
            string label = name ?? "value";

            string message = fieldName is not null
                ? $"{label} is invalid in {fieldName}"
                : $"{label} is invalid";

            return Error.Validation("value.is.invalid", message);
        }


        public static Error NotFound(Guid? id = null)
        {
            string forId = id == null ? "" : $" for id '{id}'";
            return Error.NotFound("record.not.found", $"record not found{forId}");
        }

        public static Error ValueIsRequired(string? name = null)
        {
            string label = name ?? " ";
            return Error.Validation("length.is.invalid", $"invalid {label} length");
        }

        public static Error AlreadyDeleted(Guid id)
        {
            return Error.Validation("record.already.deleted", $"Record with id {id} is already deleted");
        }
    }

    public static class Infrastructure
    {
        public static Error UnknownException(string message)
        {
            return Error.Failure("infrastructure.unknown", message);
        }
    }
}