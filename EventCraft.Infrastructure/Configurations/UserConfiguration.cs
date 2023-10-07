using EventCraft.Domain.Events;
using EventCraft.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventCraft.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new UserId(value));

        builder.HasMany(u => u.UserEvents)
            .WithOne(e => e.Author)
            .HasForeignKey(e => e.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.AttendeeRequests)
            .WithOne(ar => ar.User)
            .HasForeignKey(ar => ar.UserId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}