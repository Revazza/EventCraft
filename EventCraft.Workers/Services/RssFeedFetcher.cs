using EventCraft.Domain.FeedItems;
using EventCraft.Domain.RssFeedRequests;
using EventCraft.Domain.RssFeedWebsites;
using EventCraft.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml;

namespace EventCraft.Workers.Services;

public class RssFeedFetcher
{
    private readonly DbContextOptions<EventCraftDbContext> _options;

    public RssFeedFetcher(
        DbContextOptions<EventCraftDbContext> options)
    {
        _options = options;
    }

    public async Task StartAsync()
    {
        await Task.Run(async () =>
        {
            while (true)
            {
                await ProcessFeedRequests();
                await Task.Delay(1000);
                //await Task.Delay((int)RssFeedInterval.OneMinute);
            }
        });

    }

    private async Task<string> FetchAsync(string url)
    {
        var response = await new HttpClient().GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    private async Task ProcessFeedRequests()
    {
        using var context = new EventCraftDbContext(_options);

        var feedRequests = await context
            .RssFeedRequests
            .ToListAsync();


        var maxTasks = 10;
        var taskIndex = 0;
        var tasks = new Task[maxTasks];

        foreach (var feedRequest in feedRequests)
        {
            var task = Task.Run(async () => await ProcessFeedRequest(feedRequest));

            tasks[taskIndex++] = task;

            if (taskIndex == maxTasks)
            {
                Task.WaitAll(tasks);
                taskIndex = 0;
                tasks = new Task[maxTasks];
            }
        }

    }

    private async Task ProcessFeedRequest(RssFeedRequest request)
    {
        var url = request.Url;
        using var context = new EventCraftDbContext(_options);

        var strXml = await FetchAsync(url);
        var feed = XmlToSyndicationFeed(strXml);
        if (feed is null)
        {
            return;
        }
        await AddFeedItems(feed, context);
        context.RssFeedRequests.Remove(request);

        await context.SaveChangesAsync();

    }

    private async Task AddFeedItems(
        SyndicationFeed feed,
        EventCraftDbContext context)
    {
        var feedItems = new List<FeedItem>();

        foreach (var item in feed.Items)
        {
            var feedItem = CreateFeedItem(item);
            feedItems.Add(feedItem);
        }

        await context.FeedItems.AddRangeAsync(feedItems);

        await context.SaveChangesAsync();

    }

    private FeedItem CreateFeedItem(SyndicationItem item)
    {
        // convert html text to normal text
        // example: <h1>Hello World</h1> -> Hello World
        var summary = item.Summary.Text;
        var parsedSummary = Regex.Replace(summary, "<[^>]*>", "").Trim();
        parsedSummary = parsedSummary.Replace("\n", " ");

        var newFeedItem = new FeedItem()
        {
            Title = item.Title.Text,
            Summary = parsedSummary,
            Author = item.Authors.FirstOrDefault()?.Name ?? "Unknown",
            Link = item.Links.FirstOrDefault()?.Uri.OriginalString ?? "Unknown URL",
        };

        return newFeedItem;
    }

    private SyndicationFeed? XmlToSyndicationFeed(string strXml)
    {
        var stringReader = new StringReader(strXml);
        try
        {
            var reader = XmlReader.Create(stringReader);
            return SyndicationFeed.Load(reader);
        }
        catch (Exception)
        {
            return null;
        }

    }

}