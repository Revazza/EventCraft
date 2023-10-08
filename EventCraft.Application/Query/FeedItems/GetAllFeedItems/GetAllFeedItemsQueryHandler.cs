using EventCraft.Application.Common;
using EventCraft.Domain.FeedItems;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EventCraft.Application.Query.FeedItems.GetAllFeedItems;

public record GetAllFeedItemsQuery() : IRequest<Response>;

public class GetAllFeedItemsQueryHandler : IRequestHandler<GetAllFeedItemsQuery, Response>
{
    private readonly IMemoryCache _cache;
    private const string CACHE_KEY = "feedItems";

    public GetAllFeedItemsQueryHandler(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<Response> Handle(GetAllFeedItemsQuery request, CancellationToken cancellationToken)
    {
        _cache.TryGetValue("feedItems", out IEnumerable<FeedItem> feedItems);

        if (feedItems is null)
        {

        }


        return Response.Ok();
    }


}