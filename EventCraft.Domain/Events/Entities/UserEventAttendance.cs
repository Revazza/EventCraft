using EventCraft.Domain.Users;

namespace EventCraft.Domain.Events.Entities;

public class UserEventAttendance
{
    public UserId UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    public EventId EventId { get; set; } = null!;
    public Event Event { get; set; } = null!;
}