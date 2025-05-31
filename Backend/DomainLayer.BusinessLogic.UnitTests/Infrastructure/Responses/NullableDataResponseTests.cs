namespace DomainLayer.BusinessLogic.UnitTests.Infrastructure.Responses;

using Common.Contracts.TranslationManagement;
using Common.Interface.Enums;
using DomainLayer.BusinessLogic.Infrastructure.Responses;

public class NullableDataResponseTests
{
    [Fact]
    public void NullableDataResponseShouldWrapValueCorrectly()
    {
        // Arrange
        var dto = new TranslationDto
        {
            SourceLanguage = LanguageType.English,
            TargetLanguage = LanguageType.Lebanese,
            TextToTranslate = "How are you?",
        };
        var dtoNull = null as TranslationDto;

        // Act
        var response = new NullableDataResponse<TranslationDto>(dto);
        var nullResponse = new NullableDataResponse<TranslationDto>(dtoNull);

        // Assert
        Assert.Equivalent(dto, response.Data);
        Assert.Equivalent(dtoNull, nullResponse.Data);
    }
}