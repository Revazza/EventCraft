using EventCraft.Application.Common;
using EventCraft.Application.Interfaces;
using EventCraft.Domain.FeedItems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EventCraft.Application.Query.FeedItems.GetAllFeedItems;

public record GetAllFeedItemsQuery() : IRequest<Response>;

public class GetAllFeedItemsQueryHandler : IRequestHandler<GetAllFeedItemsQuery, Response>
{
    private readonly IMemoryCache _cache;
    private readonly IFeedItemRepository _feedItemRepository;
    private const string CACHE_KEY = "feedItems";

    public GetAllFeedItemsQueryHandler(
        IMemoryCache cache,
        IFeedItemRepository feedItemRepository)
    {
        _cache = cache;
        _feedItemRepository = feedItemRepository;
    }

    public async Task<Response> Handle(GetAllFeedItemsQuery request, CancellationToken cancellationToken)
    {
        _cache.TryGetValue(CACHE_KEY, out IEnumerable<FeedItem>? feedItems);

        if (feedItems is null || !feedItems.Any() ||
             DateTime.UtcNow > feedItems.First().CreatedAt.AddHours(1))
        {
            feedItems = await _feedItemRepository.GetAll().AsNoTracking().ToListAsync();
        }

        _cache.Set(CACHE_KEY, feedItems);

        return Response.Ok().Add("feedItems", feedItems);
    }


}