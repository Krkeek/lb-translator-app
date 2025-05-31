namespace DomainLayer.BusinessLogic.Infrastructure.Responses;

/// <summary>
/// Represents a response indicating no content (HTTP 204).
/// </summary>
public class NoContentResponse
{
    /// <summary>
    /// Instance.
    /// </summary>
    public static readonly NoContentResponse Instance = new NoContentResponse();

    private NoContentResponse()
    {
    }
}