namespace PersistenceLayer.DataAccess.Entities.Identity;

using PersistenceLayer.DataAccess.Entities.Configuration;
using PersistenceLayer.DataAccess.Entities.Core;
using PersistenceLayer.DataAccess.Entities.Log;

/// <summary>
/// UserEntity.
/// </summary>
public class UserEntity
{
    /// <summary>
    /// Gets or sets unique user identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets user's first name.
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets user's last name.
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Gets or sets user's phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets user's email address.
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Gets or sets timestamp of last login.
    /// </summary>
    public DateTime? LastLogin { get; set; }

    /// <summary>
    /// Gets or sets username for login.
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// Gets or sets login restriction until date.
    /// </summary>
    public DateTime? DenyLoginUntil { get; set; }

    /// <summary>
    /// Gets or sets user's date of birth.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Gets or sets user's country.
    /// </summary>
    public string Country { get; set; } = default!;

    /// <summary>
    /// Gets or sets account creation timestamp.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether indicates if the user is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets hashed password.
    /// </summary>
    public string PasswordHash { get; set; } = default!;

    /// <summary>
    /// Gets or sets user's role or permission group.
    /// </summary>
    public string Role { get; set; } = default!;

    /// <summary>
    /// Gets or sets related preferences.
    /// </summary>
    public ICollection<PreferenceEntity> Preferences { get; set; } = [];

    /// <summary>
    /// Gets or sets related subscriptions.
    /// </summary>
    public ICollection<SubscriptionEntity> Subscriptions { get; set; } = [];

    /// <summary>
    /// Gets or sets related translations.
    /// </summary>
    public ICollection<TranslationEntity> Translations { get; set; } = [];

    /// <summary>
    /// Gets or sets related top translations.
    /// </summary>
    public ICollection<TopTranslationEntity> TopTranslations { get; set; } = [];

    /// <summary>
    /// Gets or sets related log entries.
    /// </summary>
    public ICollection<LogEntryEntity> LogEntries { get; set; } = [];
}