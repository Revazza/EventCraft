using EventCraft.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventCraft.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configure)
    {
        services.AddDbContext<EventCraftDbContext>(x =>
        {
            x.UseSqlServer(configure.GetConnectionString(EventCraftDbContext.ConnectionStringName))
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true);
        });


        return services;
    }

}