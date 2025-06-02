namespace Application.CommandLine.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PersistenceLayer.DataAccess.Context;
using Application.CommandLine.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Registers application-wide dependencies.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds all application and domain services to the container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">config.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,  IConfiguration configuration)
    {
        services.AddSingleton(configuration);

        // AppDbContext registration
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // services
        services.AddSingleton<PrepareDatabaseService>();

        return services;
    }
}