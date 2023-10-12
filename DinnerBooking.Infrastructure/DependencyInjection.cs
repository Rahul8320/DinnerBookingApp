using DinnerBooking.Application.Common.Interfaces.Auth;
using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Application.Common.Interfaces.Services;
using DinnerBooking.Infrastructure.Auth;
using DinnerBooking.Infrastructure.Persistence;
using DinnerBooking.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DinnerBooking.Infrastructure.Persistence.Repository;

namespace DinnerBooking.Infrastructure;

/// <summary>
/// Represents the dependency injections of the infrastructure layers.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds a dependency injection for repositories and database contexts.
    /// </summary>
    /// <param name="services">Represents application builder services</param>
    /// <param name="configuration">Represents application builder configurations</param>
    /// <returns>Returns a IServiceCollection interface</returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        // add db context provider
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer());
        // add repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    /// <summary>
    /// Adds dependency injections for authentications like jwt token generator
    /// </summary>
    /// <param name="services">Represents applications builder services</param>
    /// <param name="configuration">Represents application builder configurations</param>
    /// <returns>Returns a IServiceCollection interface</returns>
    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)
                )
            });

        return services;
    }
}