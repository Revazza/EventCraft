

using EventCraft.Domain.Events;
using EventCraft.Domain.Events.Entities;
using Microsoft.AspNetCore.Identity;

namespace EventCraft.Domain.Users;

public record UserId(Guid Value)
{
    public static UserId Create()
    {
        return new UserId(Guid.NewGuid());
    }
}

public class UserRole : IdentityRole<UserId>
{

}

public class User : IdentityUser<UserId>
{
    public List<Event> UserEvents { get; set; }
    public List<UserEventAttendance> EventsToAttend { get; set; }
    public List<AttendeeRequest> AttendeeRequests { get; set; }

    public User()
    {
        UserEvents = new List<Event>();
        EventsToAttend = new List<UserEventAttendance>();
        AttendeeRequests = new List<AttendeeRequest>();
    }
}