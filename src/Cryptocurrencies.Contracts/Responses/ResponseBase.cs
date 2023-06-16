using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Responses;

public abstract class ResponseBase<T>
{
    [JsonPropertyName("data")]
    public T Data { get; init; } = default!;
    
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; init; }
}