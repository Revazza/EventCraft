using System.ComponentModel.DataAnnotations;

namespace EventCraft.Domain.FeedItems;

public class FeedItem
{
    //To save time I'll use data annotations
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public int PublisherId { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Summary { get; set; }
    public string? Link { get; set; }

}