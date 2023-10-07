using EventCraft.Application;
using EventCraft.Workers;

namespace EventCraft.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, ConfigurationManager configure)
    {
        services.AddBackgroundWorkers()
            .AddApplication(configure);

        return services;
    }
}
