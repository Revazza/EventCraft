using EventCraft.Domain.RssFeedRequests;
using EventCraft.Domain.RssFeedWebsites;
using EventCraft.Infrastructure.Db;
using EventCraft.Workers.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventCraft.Workers.Services;

public class RssFeedWatcher
{
    private readonly DbContextOptions<EventCraftDbContext> _options;

    public RssFeedWatcher(DbContextOptions<EventCraftDbContext> options)
    {
        _options = options;
    }

    public async Task StartAsync()
    {
        await Task.Run(async () =>
        {
            while (true)
            {
                await ProcessRssFeedWebsites();
                await Task.Delay(1000);
                //await Task.Delay((int)RssFeedInterval.OneMinute);
            }
        });

    }

    private async Task ProcessRssFeedWebsites()
    {
        using var context = new EventCraftDbContext(_options);
        var websites = await context.RssFeedWebsites
            .AsNoTracking()
            .ToListAsync();

        var maxTasks = 10;
        var taskIndex = 0;
        var tasks = new Task[maxTasks];
        //Process 10 tasks at a time
        foreach (var website in websites)
        {
            var task = Task.Run(async () => await ProcessRssFeedWebsite(website));
            tasks[taskIndex++] = task;
            if (taskIndex == maxTasks)
            {
                Task.WaitAll(tasks);
                taskIndex = 0;
                tasks = new Task[maxTasks];
            }

        }

    }

    private async Task ProcessRssFeedWebsite(RssFeedWebsite website)
    {
        var response = await new HttpClient().GetAsync(website.Url);
        var strXml = await response.Content.ReadAsStringAsync();
        var hash = strXml.CalculateHash();
        if (website.Hash == hash)
        {
            return;
        }

        using var context = new EventCraftDbContext(_options);

        await context.RssFeedRequests.AddAsync(new RssFeedRequest
        {
            Id = Guid.NewGuid(),
            Url = website.Url,
        });

        website.Hash = hash;

        context.RssFeedWebsites.Update(website);
        await context.SaveChangesAsync();

    }

}