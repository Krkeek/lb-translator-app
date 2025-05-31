namespace DomainLayer.BusinessLogic.Infrastructure.Responses;

/// <summary>
/// Represents a response that might contain data or be null.
/// </summary>
/// <typeparam name="T">The type of the data.</typeparam>
public class NullableDataResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NullableDataResponse{T}"/> class.
    /// </summary>
    /// <param name="data">data.</param>
    public NullableDataResponse(T? data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Gets data.
    /// </summary>
    public T? Data { get; }
}