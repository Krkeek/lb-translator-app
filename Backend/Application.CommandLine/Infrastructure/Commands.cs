namespace Application.CommandLine.Infrastructure;

using Application.CommandLine.Utilities;

using Cocona;

/// <summary>
/// List of CLI Commands.
/// </summary>
public class Commands
{
    private readonly PrepareDatabaseService _prepareDatabaseService;

    /// <summary>
    /// Initializes a new instance of the <see cref="Commands"/> class.
    /// </summary>
    /// <param name="prepareDatabaseService">Service.</param>
    public Commands(PrepareDatabaseService prepareDatabaseService)
    {
        this._prepareDatabaseService = prepareDatabaseService;
    }

    /// <summary>
    /// PrepareDatabase Command.
    /// </summary>
    [Command("prepare-database")]
    public void PrepareDatabaseCommand()
    {
        CommandLineUtility.WriteTitle("Command: Preparing Database");
        try
        {
            this._prepareDatabaseService.DropAndCreateDatabase();
            this._prepareDatabaseService.ApplyMigration();
        }
        catch (Exception ex)
        {
            CommandLineUtility.WriteFailureMessage("Failed to prepare database", ex.ToString());
            Environment.Exit(1);
        }
    }
}