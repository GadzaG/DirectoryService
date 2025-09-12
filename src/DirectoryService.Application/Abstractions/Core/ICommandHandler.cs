using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Application.Abstractions.Core;

public interface ICommandHandler<TResponse, in TCommand>
    where TCommand : ICommand
{
    public Task<Result<TResponse, ErrorList>> Handle(
        TCommand command,
        CancellationToken ct = default);
}

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    public Task<UnitResult<ErrorList>> Handle(
        TCommand command,
        CancellationToken ct = default);
}