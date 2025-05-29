namespace DomainLayer.BusinessLogic.Core;

using Common.Interface.Enums;
using PersistenceLayer.DataAccess.Entities;

/// <summary>
/// What a Translator should do.
/// </summary>
public interface IBaseTranslator
{
    /// <summary>
    /// Gets or sets SourceLanguage.
    /// </summary>
    LanguageType SourceLanguage { get; set; }

    /// <summary>
    /// Gets or sets TargetLanguage.
    /// </summary>
    LanguageType TargetLanguage { get; set; }

    /// <summary>
    /// Gets the number of times this translator has been used.
    /// </summary>
    int UsageCount { get; }

    /// <summary>
    /// Translation Method.
    /// </summary>
    /// <param name="word">Word to translate.</param>
    /// <returns>Translated word.</returns>
    Task<WordEntity> TranslateWordAsync(WordEntity word);

    /// <summary>
    /// Translates a full sentence or phrase.
    /// </summary>
    /// <param name="sentence">The sentence or phrase to translate.</param>
    /// <returns>The translated text.</returns>
    Task<string> TranslateSentenceAsync(string sentence);

    /// <summary>
    /// Determines whether this translator can handle the given word based on language or other constraints.
    /// </summary>
    /// <param name="word">The word to evaluate.</param>
    /// <returns>True if this translator can handle the word; otherwise, false.</returns>
    bool CanHandle(WordEntity word);

    /// <summary>
    /// Indicates whether this translator is currently enabled and available for use.
    /// </summary>
    /// <returns>True if enabled; otherwise, false.</returns>
    bool IsEnabled();
}