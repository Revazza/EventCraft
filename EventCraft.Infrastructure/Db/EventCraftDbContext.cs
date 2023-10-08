using EventCraft.Domain.Events;
using EventCraft.Domain.Events.Entities;
using EventCraft.Domain.FeedItems;
using EventCraft.Domain.RssFeedRequests;
using EventCraft.Domain.RssFeedWebsites;
using EventCraft.Domain.Users;
using EventCraft.Infrastructure.Common.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;

namespace EventCraft.Infrastructure.Db;

public class EventCraftDbContext : IdentityDbContext<User, UserRole, UserId>
{
    public const string ConnectionStringName = "EventCraftConnection";
    public DbSet<Event> Events { get; set; }
    public DbSet<AttendeeRequest> AttendeeRequests { get; set; }
    public DbSet<FeedItem> FeedItems { get; set; }
    public DbSet<RssFeedWebsite> RssFeedWebsites { get; set; }
    public DbSet<RssFeedRequest> RssFeedRequests { get; set; }


    public EventCraftDbContext(DbContextOptions<EventCraftDbContext> opt) : base(opt)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventCraftDbContext).Assembly);
        modelBuilder.SeedData();
        base.OnModelCreating(modelBuilder);

    }
}