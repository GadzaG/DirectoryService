using DirectoryService.Application.Abstractions.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryService.Infrastructure.Postgres;

public static class Inject
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetSection(PostgresOptions.POSTGRES));
        services.AddDbContext<DirectoryServiceDbContext>();
        services.AddDbContext<IReadDbContext, DirectoryServiceDbContext>();
        return services;
    }
}