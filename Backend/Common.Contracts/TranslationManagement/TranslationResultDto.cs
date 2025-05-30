namespace Common.Contracts.TranslationManagement;

using Common.Interface.Enums;

/// <summary>
/// Represents the result of a translation operation.
/// </summary>
public class TranslationResultDto
{
    /// <summary>
    /// Gets or sets the original input text.
    /// </summary>
    public required string OriginalText { get; set; }

    /// <summary>
    /// Gets or sets the translated output text.
    /// </summary>
    public required string TranslatedText { get; set; }

    /// <summary>
    /// Gets or sets the language of the original text.
    /// </summary>
    public required LanguageType SourceLanguage { get; set; }

    /// <summary>
    /// Gets or sets the language of the translated text.
    /// </summary>
    public required LanguageType TargetLanguage { get; set; }

    /// <summary>
    /// Gets or sets the translation provider (e.g., OpenAI, Manual).
    /// </summary>
    public required TranslationProvider Provider { get; set; }
}