using System.Text.Json.Serialization;
using Cryptocurrencies.Contracts.Models;

namespace Cryptocurrencies.Contracts.Responses;

public record GetCoinResponse
{
    [JsonPropertyName("data")]
    public CoinModel Data { get; set; } = new();

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; } = 0;
}