using EventCraft.Domain.Events.Entities;
using EventCraft.Domain.Users;

namespace EventCraft.Domain.Events;

public record EventId(Guid Value)
{
    public static EventId Create()
    {
        return new EventId(Guid.NewGuid());
    }
}

public record GeoLocation(decimal Longitude, decimal Latitude);

public enum EventCategory
{
    None,
    Educational,
    Entertainment
}

public class Event
{
    public EventId EventId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int MaxNumberOfPeople { get; set; }
    public bool IsOffline { get; set; }
    public bool IsFree { get; set; }
    public decimal Price { get; set; }
    public string OnlineUrl { get; set; } = null!;
    public GeoLocation Location { get; set; } = null!;
    public EventCategory Category { get; set; }
    public User Author { get; set; } = null!;
    public UserId AuthorId { get; set; } = null!;
    public List<UserEventAttendance> Guests { get; set; }
    public List<AttendeeRequest> AttendeeRequests { get; set; }

    public Event()
    {
        Guests = new List<UserEventAttendance>();
        AttendeeRequests = new List<AttendeeRequest>();
    }


}