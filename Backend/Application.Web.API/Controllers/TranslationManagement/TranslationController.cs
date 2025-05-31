namespace Application.Web.API.Controllers.TranslationManagement;

using Application.Web.API.Infrastructure;
using Common.Contracts.TranslationManagement;
using DomainLayer.BusinessLogic.TranslationManagement.QueryHandlers;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Translation Controller.
/// </summary>
[Route("api/[controller]")]
[ProducesResponseType(typeof(TranslationDto), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ApiController]
public class TranslationController : ControllerBase
{
    /// <summary>
    /// Translates a given text using the specified translation query handler.
    /// </summary>
    /// <param name="translationDto">The text to translate from the source language.</param>
    /// <param name="queryHandler">The handler responsible for performing the translation.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>A <see cref="TranslationDto"/> representing the translated result.</returns>
    [HttpPost("translate")]
    public async Task<ActionResult<TranslationResultDto>> Translate(
        TranslationDto translationDto,
        [FromServices] IGetTranslationQueryHandler queryHandler,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(translationDto.ToString());
        var response = await queryHandler.Execute(translationDto, cancellationToken);
        return response.ToActionResult();
    }
}