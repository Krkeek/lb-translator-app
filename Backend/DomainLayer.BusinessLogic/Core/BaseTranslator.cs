namespace DomainLayer.BusinessLogic.Core;

using Common.Interface.Enums;
using PersistenceLayer.DataAccess.Entities;

/// <summary>
/// Abstract base translator providing core structure and common behaviors.
/// </summary>
public abstract class BaseTranslator : IBaseTranslator
{
    /// <summary>
    /// Usage Count.
    /// </summary>
    private readonly int _usageCount = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseTranslator"/> class.
    /// </summary>
    /// <param name="sourceLanguage">sourceLanguage.</param>
    /// <param name="targetLanguage">targetLanguage.</param>
    protected BaseTranslator(LanguageType sourceLanguage, LanguageType targetLanguage)
    {
        this.SourceLanguage = sourceLanguage;
        this.TargetLanguage = targetLanguage;
    }

    /// <inheritdoc cref="IBaseTranslator"/>
    public LanguageType SourceLanguage { get; set; }

    /// <inheritdoc cref="IBaseTranslator"/>
    public LanguageType TargetLanguage { get; set; }

    /// <inheritdoc cref="IBaseTranslator"/>
    public int UsageCount => this._usageCount;

    /// <inheritdoc cref="IBaseTranslator"/>
    public abstract Task<WordEntity> TranslateWordAsync(WordEntity word);

    /// <inheritdoc cref="IBaseTranslator"/>
    public abstract Task<string> TranslateSentenceAsync(string sentence);

    /// <inheritdoc cref="IBaseTranslator"/>
    public bool CanHandle(WordEntity word)
    {
        return word.Language == this.SourceLanguage;
    }

    /// <inheritdoc cref="IBaseTranslator"/>
    public bool IsEnabled()
    {
        return true;
    }
}