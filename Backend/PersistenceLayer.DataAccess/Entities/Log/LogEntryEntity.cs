namespace PersistenceLayer.DataAccess.Entities.Log;

using PersistenceLayer.DataAccess.Entities.Identity;

/// <summary>
/// Represents a log entry recorded by the system.
/// </summary>
public class LogEntryEntity
{
    /// <summary>
    /// Gets or sets the unique ID of the log entry.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user associated with the log entry.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the log event.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// Gets or sets the severity level of the log (e.g., Info, Error).
    /// </summary>
    public string Level { get; set; } = default!;

    /// <summary>
    /// Gets or sets the source component of the log entry.
    /// </summary>
    public string Source { get; set; } = default!;

    /// <summary>
    /// Gets or sets the main message of the log entry.
    /// </summary>
    public string Message { get; set; } = default!;

    /// <summary>
    /// Gets or sets the exception details, if any.
    /// </summary>
    public string? Exception { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the log is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the associated user entity.
    /// </summary>
    public UserEntity User { get; set; } = default!;
}