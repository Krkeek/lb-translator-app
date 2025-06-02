namespace Application.CommandLine;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.CommandLine.Configuration;
using Application.CommandLine.Infrastructure;
using Cocona;

/// <summary>
/// Entry point for the command-line application.
/// </summary>
public class Program
{
    /// <summary>
    /// Configures and runs the CLI.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        var builder = CoconaApp.CreateBuilder();

        var configPath = Path.GetFullPath("../../../../Application.Web.API/appsettings.json");
        if (!File.Exists(configPath))
        {
            throw new FileNotFoundException("appsettings.json not found", configPath);
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(configPath))
            .AddJsonFile("appsettings.json")
            .Build();

        builder.Services.AddApplicationServices(configuration);

        var app = builder.Build();
        app.AddCommands<Commands>();
        app.Run();
    }
}