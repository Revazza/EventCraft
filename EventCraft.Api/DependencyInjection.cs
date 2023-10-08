using EventCraft.Application;
using EventCraft.Infrastructure;
using EventCraft.Workers;

namespace EventCraft.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, ConfigurationManager configure)
    {
        services.AddBackgroundWorkers()
            .AddInfrastructure(configure);

        return services;
    }
}
