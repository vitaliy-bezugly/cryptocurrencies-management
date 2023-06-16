using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Models;

public record CoinHistoryModel
{
    [JsonPropertyName("priceUsd")]
    public string PriceUsd { get; set; } = string.Empty;
    
    [JsonPropertyName("time")]
    public long Time { get; set; } = 0;
}