namespace PersistenceLayer.DataAccess.Entities.Configuration;

using PersistenceLayer.DataAccess.Entities.Identity;

/// <summary>
/// Represents a user preference entry.
/// </summary>
public class PreferenceEntity
{
    /// <summary>
    /// Gets the unique identifier for the preference.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Gets the ID of the associated user.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Gets or sets the type of the preference.
    /// </summary>
    public string Type { get; set; } = default!;

    /// <summary>
    /// Gets the value of the preference.
    /// </summary>
    public string Value { get; init; } = default!;

    /// <summary>
    /// Gets the creation timestamp of the preference.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Gets a value indicating whether the preference is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; init; }

    /// <summary>
    /// Gets the associated user entity.
    /// </summary>
    public UserEntity User { get; init; } = default!;
}