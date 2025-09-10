using Microsoft.Extensions.DependencyInjection;

namespace DirectoryService.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}