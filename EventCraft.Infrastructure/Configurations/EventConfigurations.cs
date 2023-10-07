using EventCraft.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventCraft.Infrastructure.Configurations;

public class EventConfigurations : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.EventId);

        builder.Property(u => u.EventId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new EventId(value));

        builder.HasOne(x => x.Author)
            .WithMany(x => x.UserEvents)
            .HasForeignKey(x => x.AuthorId);

    }
}