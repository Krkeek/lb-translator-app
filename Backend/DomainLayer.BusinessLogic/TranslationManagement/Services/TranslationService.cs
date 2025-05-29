namespace DomainLayer.BusinessLogic.TranslationManagement.Services;

using Common.Contracts.TranslationManagement;
using Common.Interface.Enums;

/// <inheritdoc />
public class TranslationService : ITranslationService
{
    /// <inheritdoc/>
    public Task<TranslationResultDto> Translate(TranslationDto translationDto, CancellationToken cancellationToken)
    {
        return Task.FromResult(new TranslationResultDto()
        {
            OriginalText = "Hello",
            TranslatedText = "Marhaba",
            SourceLanguage = LanguageType.English,
            TargetLanguage = LanguageType.Lebanese,
            Provider = TranslationProvider.OpenAi,
        });
    }
}