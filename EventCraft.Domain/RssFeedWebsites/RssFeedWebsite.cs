using System.ComponentModel.DataAnnotations;

namespace EventCraft.Domain.RssFeedWebsites;


public enum RssFeedInterval
{
    OneMinute = 1000 * 60 * 1,
    OneHour = OneMinute * 60,
    TwoHours = OneHour * 2,
    SixHours = OneHour * 6,
    TwentyHours = OneHour * 12,
    OneDay = OneHour * 24,
}

public class RssFeedWebsite
{
    //To save time I'll use data annotations
    [Key]
    public Guid Id { get; set; }
    public RssFeedInterval Interval { get; set; } = RssFeedInterval.OneHour;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Url { get; set; } = null!;
    public string Hash { get; set; } = string.Empty;

    public RssFeedWebsite()
    {
        Id = Guid.NewGuid();
    }

}