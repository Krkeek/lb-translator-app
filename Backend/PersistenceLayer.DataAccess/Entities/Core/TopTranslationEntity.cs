namespace PersistenceLayer.DataAccess.Entities.Core;

using PersistenceLayer.DataAccess.Entities.Identity;

/// <summary>
/// Represents a top-rated or frequently used translation saved by a user.
/// </summary>
public class TopTranslationEntity
{
    /// <summary>
    /// Gets or sets the unique ID of the top translation.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the ID of the user who marked the translation.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Gets the ID of the associated translation.
    /// </summary>
    public int TranslationId { get; init; }

    /// <summary>
    /// Gets the original text of the translation.
    /// </summary>
    public string OriginalText { get; init; } = default!;

    /// <summary>
    /// Gets the source language of the original text.
    /// </summary>
    public string SourceLanguage { get; init; } = default!;

    /// <summary>
    /// Gets the target language of the translation.
    /// </summary>
    public string TargetLanguage { get; init; } = default!;

    /// <summary>
    /// Gets the date when the top translation was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Gets the date when the top translation was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; init; }

    /// <summary>
    /// Gets the associated user entity.
    /// </summary>
    public UserEntity User { get; init; } = default!;

    /// <summary>
    /// Gets the linked translation entity.
    /// </summary>
    public TranslationEntity Translation { get; init; } = default!;
}