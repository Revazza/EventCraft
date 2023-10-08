using EventCraft.Application.Interfaces;
using EventCraft.Domain.Events;
using EventCraft.Infrastructure.Db;

namespace EventCraft.Infrastructure.Repositories;

public class EventRepository : GenericRepository<Event, EventId>, IEventRepository
{

    public EventRepository(EventCraftDbContext context) : base(context)
    {

    }


}