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

        builder.Property(x => x.Price).HasPrecision(18, 18);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.UserEvents)
            .HasForeignKey(x => x.AuthorId);

        builder.OwnsOne(e => e.Location, location =>
               {
                   location.Property(l => l.Longitude).HasPrecision(18, 18).IsRequired();
                   location.Property(l => l.Latitude).HasPrecision(18, 18).IsRequired();
               });

    }
}