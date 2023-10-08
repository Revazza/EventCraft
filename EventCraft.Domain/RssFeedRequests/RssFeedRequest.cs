using System.ComponentModel.DataAnnotations;

namespace EventCraft.Domain.RssFeedRequests;

public class RssFeedRequest
{
    //To save time I'll use data annotations
    [Key]
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;

}