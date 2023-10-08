using EventCraft.Domain.RssFeedWebsites;
using Microsoft.EntityFrameworkCore;

namespace EventCraft.Infrastructure.Common.Extensions;

public static class ModelBuilderExtensions
{

    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        var websites = new List<RssFeedWebsite>()
        {
            new RssFeedWebsite(){Url= "https://pitchfork.com/rss/reviews/best/albums/"},
            new RssFeedWebsite(){Url= "https://pitchfork.com/rss/reviews/best/tracks/"},
            new RssFeedWebsite(){Url= "https://pitchfork.com/rss/reviews/best/reissues/"},
        };
        modelBuilder.Entity<RssFeedWebsite>()
            .HasData(websites);

        return modelBuilder;
    }

}