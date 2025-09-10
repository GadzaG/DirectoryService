using Microsoft.Extensions.DependencyInjection;

namespace DirectoryService.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services;
    }
}