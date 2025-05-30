namespace DomainLayer.BusinessLogic.UnitTests.TranslationManagement.Services.TranslationServiceClass;

using Common.Contracts.TranslationManagement;
using Common.Interface.Enums;
using DomainLayer.BusinessLogic.TranslationManagement.Services;
using Moq;

public class TranslateMethod
{
    private readonly ITranslationService _translationService;

    public TranslateMethod()
    {
        this._translationService = new TranslationService();
    }

    [Fact]
    public async Task ShouldReturnDummyResult()
    {
        // Arrange
        var expectedDto = new TranslationResultDto
        {
            OriginalText = "Hello",
            TranslatedText = "Marhaba",
            SourceLanguage = LanguageType.English,
            TargetLanguage = LanguageType.Lebanese,
            Provider = TranslationProvider.OpenAi,
        };

        // Act
        TranslationResultDto dummyResult = await this._translationService.Translate(It.IsAny<TranslationDto>(), CancellationToken.None);

        // Assert
        Assert.NotNull(dummyResult);
        Assert.Equivalent(dummyResult, expectedDto);
    }
}