using EventCraft.Domain.Users;

namespace EventCraft.Domain.Events.Entities;

public enum AttendeeStatus
{
    Accepted,
    Declined,
    None,
}

public class AttendeeRequest
{
    public UserId UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    public AttendeeStatus Status { get; set; } = AttendeeStatus.None;

}