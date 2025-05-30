namespace Application.Web.API.Configuration;

using DomainLayer.BusinessLogic.Core;
using DomainLayer.BusinessLogic.TranslationManagement.QueryHandlers;
using DomainLayer.BusinessLogic.TranslationManagement.Services;
using DomainLayer.BusinessLogic.TranslationManagement.Translators;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Registers application-wide dependencies.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds all application and domain services to the container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Translation services
        services.AddScoped<IBaseTranslator, EnglishToLebaneseTranslator>();
        services.AddScoped<ITranslationService, TranslationService>();
        services.AddScoped<IGetTranslationQueryHandler, GetTranslationQueryHandler>();
        return services;
    }
}