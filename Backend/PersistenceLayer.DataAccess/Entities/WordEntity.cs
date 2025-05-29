namespace PersistenceLayer.DataAccess.Entities;

using System.ComponentModel.DataAnnotations;
using Common.Interface.Enums;

/// <summary>
/// Word Entity.
/// </summary>
public class WordEntity
{
    /// <summary>
    /// Gets or sets Id...
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets Language of the word.
    /// </summary>
    public required LanguageType Language { get; set; }

    /// <summary>
    /// Gets or sets word text.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    /// Gets word translations.
    /// </summary>
    public ICollection<WordEntity>? Translations { get; init; }

    /// <summary>
    /// Gets or sets created date.
    /// </summary>
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets updated date.
    /// </summary>
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets provider used.
    /// </summary>
    public required TranslationProvider Provider { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the word is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the word is marked as approved.
    /// </summary>
    public bool IsApproved { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the word is marked as active.
    /// </summary>
    public bool IsActive { get; set; }
}