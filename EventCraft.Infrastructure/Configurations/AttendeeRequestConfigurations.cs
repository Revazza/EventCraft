using EventCraft.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventCraft.Infrastructure.Configurations;

public class AttendeeRequestConfigurations : IEntityTypeConfiguration<AttendeeRequest>
{
    public void Configure(EntityTypeBuilder<AttendeeRequest> builder)
    {
        builder.HasKey(x => x.UserId);
    }
}