using EventCraft.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventCraft.Infrastructure.Configurations;

internal class UserEventAttendanceConfigurator : IEntityTypeConfiguration<UserEventAttendance>
{
    public void Configure(EntityTypeBuilder<UserEventAttendance> builder)
    {
        builder.HasKey(x => new { x.UserId, x.EventId });

        builder.HasOne(x => x.User)
            .WithMany(x => x.EventsToAttend);

        builder.HasOne(x => x.Event)
            .WithMany(x => x.Guests);

    }
}