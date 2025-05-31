namespace DomainLayer.BusinessLogic.Infrastructure.Responses;

/// <summary>
/// Wraps a data result in a response object.
/// </summary>
/// <typeparam name="T">The type of the data.</typeparam>
public sealed class DataResponse<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataResponse{T}"/> class.
    /// </summary>
    /// <param name="data">The data to wrap.</param>
    public DataResponse(T data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Gets the wrapped data.
    /// </summary>
    public T Data { get; private set; }
}