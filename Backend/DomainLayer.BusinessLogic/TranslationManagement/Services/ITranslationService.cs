namespace DomainLayer.BusinessLogic.TranslationManagement.Services;

using Common.Contracts.TranslationManagement;

/// <summary>
/// Defines a service responsible for translating text.
/// </summary>
public interface ITranslationService
{
    /// <summary>
    /// Translates the specified input text.
    /// </summary>
    /// <param name="translationDto">The text to be translated.</param>
    /// <param name="cancellationToken">A token to cancel the translation operation.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains
    /// a <see cref="TranslationDto"/> with the translated text.
    /// </returns>
    Task<TranslationResultDto> Translate(TranslationDto translationDto, CancellationToken cancellationToken);
}