using DirectoryService.Application.Abstractions.Database;
using DirectoryService.Application.Abstractions.Database.Repositories;
using DirectoryService.Infrastructure.Postgres.Repositories;
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
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ILocationsRepository, LocationsRepository>();
        return services;
    }
}