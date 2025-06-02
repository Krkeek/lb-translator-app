namespace Application.Web.API.Configuration;

using Microsoft.EntityFrameworkCore;
using PersistenceLayer.DataAccess.Context;

/// <summary>
/// Adds EF Core database context and configurations.
/// </summary>
public static class DatabaseSetup
{
    /// <summary>
    /// Registers the database context with the specified connection string.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}