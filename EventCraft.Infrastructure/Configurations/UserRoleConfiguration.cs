using EventCraft.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EventCraft.Infrastructure.Configurations;

public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new UserId(value));

    }
}