namespace DirectoryService.Application.Abstractions.Core;

public interface IQueryHandler<TResponse, in TQuery>
    where TQuery : IQuery
{
    public Task<TResponse> Handle(
        TQuery query,
        CancellationToken ct = default);
}