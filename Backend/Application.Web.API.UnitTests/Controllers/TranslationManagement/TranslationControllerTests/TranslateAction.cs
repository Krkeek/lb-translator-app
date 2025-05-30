namespace Application.Web.API.UnitTests.Controllers.TranslationManagement.TranslationControllerTests;

using System.Net.Http.Json;
using Common.Contracts.TranslationManagement;
using Common.Interface.Enums;
using DomainLayer.BusinessLogic.Infrastructure;
using DomainLayer.BusinessLogic.TranslationManagement.QueryHandlers;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;

public class TranslateAction : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly Mock<IGetTranslationQueryHandler> _getTranslationQueryHandler;
    private readonly HttpClient _httpClient;

    public TranslateAction(WebApplicationFactory<Program> factory)
    {
        this._getTranslationQueryHandler = new Mock<IGetTranslationQueryHandler>();
        this._httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task ShouldReturn200Ok()
    {
        // Arrange
        var input = new TranslationDto
        {
            SourceLanguage = LanguageType.English,
            TargetLanguage = LanguageType.Lebanese,
            TextToTranslate = "How are you?",
        };
        var expectedResult = new TranslationResultDto
        {
            OriginalText = "Hello",
            TranslatedText = "Marhaba",
            SourceLanguage = LanguageType.English,
            TargetLanguage = LanguageType.Lebanese,
            Provider = TranslationProvider.OpenAi,
        };

        // It is not used yet, because Testing Dependency Injection is not setup yet
        this._getTranslationQueryHandler.Setup(handler => handler.Execute(input, CancellationToken.None))
            .ReturnsAsync(new DataResponse<TranslationResultDto>(expectedResult));

        // Act
        var response = await this._httpClient.PostAsJsonAsync("/api/translation/translate", input);

        // Assert
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<TranslationResultDto>();
        Assert.NotNull(response);
        Assert.Equivalent(expectedResult, result);
    }
}