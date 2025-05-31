namespace Application.Web.API.Infrastructure;

using DomainLayer.BusinessLogic.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Extensions for the response to create the ActionResult.
/// </summary>
public static class ResponseExtensions
{
    /// <summary>
    /// Extension for the query response.
    /// </summary>
    /// <typeparam name="T">type of the data response.</typeparam>
    /// <param name="response">response to convert to ActionResult.</param>
    /// <returns>converted ActionResult.</returns>
    public static ActionResult<T> ToActionResult<T>(this DataResponse<T> response)
    {
    ArgumentNullException.ThrowIfNull(response);
    return new OkObjectResult(response.Data);
    }

        /// <summary>
        /// Extension for the query response.
        /// </summary>
        /// <typeparam name="T">type of the data response.</typeparam>
        /// <param name="response">response to convert to ActionResult.</param>
        /// <returns>converted ActionResult.</returns>
    public static ActionResult<T> ToActionResult<T>(this NullableDataResponse<T> response)
        {
            ArgumentNullException.ThrowIfNull(response);

            if (response.Data is null)
            {
                return new NoContentResult();
            }
            else
            {
                return new OkObjectResult(response.Data);
            }
        }

        /// <summary>
        /// Extension for the query response.
        /// </summary>
        /// <param name="response">response to convert to ActionResult.</param>
        /// <returns>converted ActionResult.</returns>
    public static ActionResult ToActionResult(this EmptyResponse response)
        {
            ArgumentNullException.ThrowIfNull(response);
            return new OkResult();
        }

        /// <summary>
        /// Extension for the query response.
        /// </summary>
        /// <param name="response">response to convert to ActionResult.</param>
        /// <returns>converted ActionResult.</returns>
    public static ActionResult ToActionResult(this NoContentResponse response)
        {
            ArgumentNullException.ThrowIfNull(response);
            return new NoContentResult();
        }
}
