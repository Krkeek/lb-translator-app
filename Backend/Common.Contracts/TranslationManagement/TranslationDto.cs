namespace Common.Contracts.TranslationManagement;

using Common.Interface.Enums;

/// <summary>
/// Represents a translation request from the client.
/// </summary>
public class TranslationDto
{
    /// <summary>
    /// Gets or sets the text to translate.
    /// </summary>
    public required string TextToTranslate { get; set; }

    /// <summary>
    /// Gets or sets the source language.
    /// </summary>
    public required LanguageType SourceLanguage { get; set; }

    /// <summary>
    /// Gets or sets the target language.
    /// </summary>
    public required LanguageType TargetLanguage { get; set; }
}