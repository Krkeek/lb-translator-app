namespace Application.CommandLine.Infrastructure;

using Application.CommandLine.Utilities;
using Common.Interface.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersistenceLayer.DataAccess.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

/// <summary>
/// Prepare Database Service.
/// </summary>
public class PrepareDatabaseService
{
    private readonly DatabaseCredentials _credentials;
    private readonly string _connectionString;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="PrepareDatabaseService"/> class.
    /// </summary>
    /// <param name="serviceProvider">The application's service provider.</param>
    /// <param name="configuration">The configuration containing the connection string.</param>
    public PrepareDatabaseService(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        this._serviceProvider = serviceProvider;
        this._connectionString = configuration.GetConnectionString("DefaultConnection") !;

        var builder = new SqlConnectionStringBuilder(this._connectionString);
        this._credentials = new DatabaseCredentials(
            builder.DataSource,
            builder.InitialCatalog,
            builder.UserID,
            builder.Password);
    }

    /// <summary>
    /// DropAndCreateDatabase.
    /// </summary>
    public void DropAndCreateDatabase()
    {
        Console.WriteLine("Dropping and recreating database...");
        var database = this._credentials.database;

        if (string.IsNullOrWhiteSpace(database) || database.Any(c => !char.IsLetterOrDigit(c) && c != '_'))
        {
            throw new InvalidOperationException("Invalid database name.");
        }

        var masterConnectionString = new SqlConnectionStringBuilder(this._connectionString)
        {
            InitialCatalog = "master",
        }.ToString();

        var sql =
            $"""
             IF DB_ID('{database}') IS NOT NULL
             BEGIN
                 ALTER DATABASE [{database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 DROP DATABASE [{database}];
             END
             CREATE DATABASE [{database}];
             """;

        using var connection = new SqlConnection(masterConnectionString);
        connection.Open();

        using var command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();

        CommandLineUtility.WriteSuccessMessage("Database dropped and recreated successfully.");
    }

    /// <summary>
    /// ApplyMigration.
    /// </summary>
    public void ApplyMigration()
    {
        Console.WriteLine("Applying EF Core migrations...");

        using var scope = this._serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
        CommandLineUtility.WriteSuccessMessage("EF Core migrations applied successfully.");
    }
}