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

public class Event
{
    public EventId EventId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public User Author { get; set; } = null!;
    public UserId AuthorId { get; set; } = null!;
    public List<UserEventAttendance> Guests { get; set; }
    //public GeoLocation Location { get; set; } = null!;
    public List<AttendeeRequest> AttendeeRequests { get; set; }

    public Event()
    {
        Guests = new List<UserEventAttendance>();
        AttendeeRequests = new List<AttendeeRequest>();
    }


}