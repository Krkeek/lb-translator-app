namespace DomainLayer.BusinessLogic.UnitTests.TranslationManagement.QueryHandlers.GetTranslationQueryHandlerClass;

using Common.Contracts.TranslationManagement;
using Common.Interface.Enums;
using DomainLayer.BusinessLogic.TranslationManagement.QueryHandlers;
using DomainLayer.BusinessLogic.TranslationManagement.Services;
using Moq;

public class ExecuteMethod
{
    private readonly Mock<ITranslationService> _mockTranslationService;
    private readonly GetTranslationQueryHandler _handler;

    public ExecuteMethod()
    {
        this._mockTranslationService = new Mock<ITranslationService>();
        this._handler = new GetTranslationQueryHandler(this._mockTranslationService.Object);
    }

    [Fact]
    public async Task ShouldReturnTranslatedText()
    {
        // Arrange
        var input = new TranslationDto
        {
            SourceLanguage = LanguageType.English,
            TargetLanguage = LanguageType.Lebanese,
            TextToTranslate = "How are you?",
        };
        var expectedDto = new TranslationResultDto
        {
            SourceLanguage = LanguageType.English,
            TargetLanguage = LanguageType.Lebanese,
            OriginalText = "How are you?",
            TranslatedText = "Kefak?",
            Provider = TranslationProvider.OpenAi,
        };
        this._mockTranslationService
            .Setup(service => service.Translate(input, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedDto);

        // Act
        var response = await this._handler.Execute(input, CancellationToken.None);
        TranslationResultDto result = response.Data;

        // Assert
        Assert.NotNull(response);
        Assert.Equal(expectedDto.OriginalText, result.OriginalText);
        Assert.Equal(expectedDto.TranslatedText, result.TranslatedText);
        Assert.Equal(expectedDto.SourceLanguage, result.SourceLanguage);
        Assert.Equal(expectedDto.TargetLanguage, result.TargetLanguage);
        Assert.Equal(expectedDto.Provider, result.Provider);
    }
}