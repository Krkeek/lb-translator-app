namespace Application.Web.API.UnitTests.Configuration;

using Application.Web.API.Configuration;
using DomainLayer.BusinessLogic.Core;
using DomainLayer.BusinessLogic.TranslationManagement.QueryHandlers;
using DomainLayer.BusinessLogic.TranslationManagement.Services;
using Microsoft.Extensions.DependencyInjection;

public class DependencyInjectionTests
{
    [Fact]
    public void AllServicesAreResolvable()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddApplicationServices();
        var provider = services.BuildServiceProvider();

        // Act & Assert
        Assert.NotNull(provider.GetRequiredService<ITranslationService>());
        Assert.NotNull(provider.GetRequiredService<IGetTranslationQueryHandler>());
        Assert.NotNull(provider.GetRequiredService<IBaseTranslator>());
    }
}