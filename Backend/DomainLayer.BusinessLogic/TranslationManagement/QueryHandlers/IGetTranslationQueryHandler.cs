namespace DomainLayer.BusinessLogic.TranslationManagement.QueryHandlers;

using Common.Contracts.TranslationManagement;
using DomainLayer.BusinessLogic.Infrastructure;

/// <summary>
/// Defines a handler for executing translation queries.
/// </summary>
public interface IGetTranslationQueryHandler
{
    /// <summary>
    /// Executes the translation operation for the specified input text.
    /// </summary>
    /// <param name="translationDto">The text that needs to be translated.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a <see cref="DataResponse{TranslationDto}"/> with the translated text.
    /// </returns>
    Task<DataResponse<TranslationResultDto>> Execute(TranslationDto translationDto, CancellationToken cancellationToken);
}