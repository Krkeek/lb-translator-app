namespace DomainLayer.BusinessLogic.TranslationManagement.QueryHandlers;

using Common.Contracts.TranslationManagement;
using DomainLayer.BusinessLogic.Infrastructure.Responses;
using DomainLayer.BusinessLogic.TranslationManagement.Services;

/// <inheritdoc />
public class GetTranslationQueryHandler : IGetTranslationQueryHandler
{
    private readonly ITranslationService _translationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTranslationQueryHandler"/> class.
    /// </summary>
    /// <param name="translationService">translationService.</param>
    public GetTranslationQueryHandler(ITranslationService translationService)
    {
        this._translationService = translationService;
    }

    /// <inheritdoc/>
    public async Task<DataResponse<TranslationResultDto>> Execute(TranslationDto translationDto, CancellationToken cancellationToken)
    {
        TranslationResultDto translationResultDto = await this._translationService.Translate(translationDto, cancellationToken);
        return new DataResponse<TranslationResultDto>(translationResultDto);
    }
}