using EventCraft.Domain.FeedItems;

namespace EventCraft.Application.Interfaces;

public interface IFeedItemRepository : IGenericRepository<FeedItem, Guid>
{

}
