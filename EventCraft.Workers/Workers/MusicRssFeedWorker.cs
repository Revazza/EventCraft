using EventCraft.Infrastructure.Db;
using EventCraft.Workers.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EventCraft.Workers.Workers;

public class MusicRssFeedWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public MusicRssFeedWorker(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<EventCraftDbContext>>();
        var watcher = new RssFeedWatcher(options);
        var fetcher = new RssFeedFetcher(options);
        var task1 = watcher.StartAsync();
        var task2 = fetcher.StartAsync();

        await Task.WhenAll(task1, task2);
        await Console.Out.WriteLineAsync();

    }

}