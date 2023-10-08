using EventCraft.Application.Interfaces;
using EventCraft.Domain.FeedItems;
using EventCraft.Infrastructure.Db;

namespace EventCraft.Infrastructure.Repositories;

public class FeedItemRepository : GenericRepository<FeedItem, Guid>, IFeedItemRepository
{
    public FeedItemRepository(EventCraftDbContext context) : base(context)
    {

    }

}