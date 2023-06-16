using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Responses;

public record ResponseBase<T>
{
    public ResponseBase(IReadOnlyCollection<T> data, long timestamp)
    {
        Data = data;
        Timestamp = timestamp;
    }
    
    [JsonPropertyName("data")]
    public IReadOnlyCollection<T> Data { get; init; }
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; init; }
}