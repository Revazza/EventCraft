using EventCraft.Domain.Events;

namespace EventCraft.Application.Interfaces;

public interface IEventRepository : IGenericRepository<Event, EventId>
{

}
