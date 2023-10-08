using EventCraft.Application;
using EventCraft.Application.Authentication;
using EventCraft.Application.Interfaces;
using EventCraft.Application.Services;
using EventCraft.Domain.Users;
using EventCraft.Infrastructure.Db;
using EventCraft.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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
        })
            .AddIdentity<User, UserRole>()
            .AddEntityFrameworkStores<EventCraftDbContext>()
            .AddDefaultTokenProviders();

        services.AddApplication(configure)
            .AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFeedItemRepository, FeedItemRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }

}