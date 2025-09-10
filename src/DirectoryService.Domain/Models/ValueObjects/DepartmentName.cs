using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Models.ValueObjects;

public record DepartmentName
{
    private DepartmentName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<DepartmentName, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.General.ValueIsRequired(nameof(DepartmentName));
        if(value.Length < Constants.MIN_DEPARTMENT_NAME_LENGTH || value.Length > Constants.MAX_DEPARTMENT_NAME_LENGTH)
            return Errors.General.ValueIsInvalid(nameof(DepartmentName));
        return new DepartmentName(value);
    }
}