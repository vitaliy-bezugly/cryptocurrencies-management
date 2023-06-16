using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Responses;

public abstract class CollectionResponseBase<T>
{
    [JsonPropertyName("data")]
    public IReadOnlyCollection<T> Data { get; init; } = Array.Empty<T>();

    [JsonPropertyName("timestamp")] 
    public long Timestamp { get; init; } = 0;
}