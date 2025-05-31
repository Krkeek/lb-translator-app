namespace DomainLayer.BusinessLogic.Infrastructure.Responses;

/// <summary>
/// Represents a successful response with no data (HTTP 200).
/// </summary>
public class EmptyResponse
{
    /// <summary>
    /// Instance.
    /// </summary>
    public static readonly EmptyResponse Instance = new EmptyResponse();

    private EmptyResponse()
    {
    }
}
