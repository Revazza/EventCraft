using EventCraft.Workers.Providers.BillBoardProvider;
using EventCraft.Workers.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace EventCraft.Workers;

public static class DependencyInjection 
{
    public static IServiceCollection AddBackgroundWorkers(this IServiceCollection services)
    {
        services.AddHostedService<BillBoardWorker>();
        return services;
    }

}