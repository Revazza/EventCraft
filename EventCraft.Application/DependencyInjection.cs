using EventCraft.Application.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace EventCraft.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configure)
    {
        services.AddAuthenticationConfigurations(configure);
        
        return services;
    }

    private static IServiceCollection AddAuthenticationConfigurations(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var issuer = configuration[$"{JwtSettings.SectionName}:Issuer"]!;
        var audience = configuration[$"{JwtSettings.SectionName}:Audience"]!;
        var secretKey = configuration[$"{JwtSettings.SectionName}:SecretKey"]!;
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("User",
                policy => policy.RequireClaim(ClaimTypes.Role, "user"));

        });

        return services;
    }

}
