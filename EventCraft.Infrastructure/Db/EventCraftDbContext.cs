using EventCraft.Domain.Events;
using EventCraft.Domain.Events.Entities;
using EventCraft.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventCraft.Infrastructure.Db;

public class EventCraftDbContext : IdentityDbContext<User, UserRole, UserId>
{
    public const string ConnectionStringName = "EventCraftConnection";
    public DbSet<Event> Events { get; set; }
    public DbSet<AttendeeRequest> AttendeeRequests { get; set; }


    public EventCraftDbContext(DbContextOptions<EventCraftDbContext> opt) : base(opt)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventCraftDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

    }
}