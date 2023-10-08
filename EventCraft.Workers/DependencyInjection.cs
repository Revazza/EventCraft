using EventCraft.Workers.Workers;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace EventCraft.Workers;

public static class DependencyInjection
{
    public static IServiceCollection AddBackgroundWorkers(this IServiceCollection services)
    {
        services.AddHostedService<MusicRssFeedWorker>();
        services.AddLogging(builder =>
        {
            builder.AddSerilog();
        });
        return services;
    }
}