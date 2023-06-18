using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Dtos;

public record CoinHistoryDto
{
    [JsonPropertyName("priceUsd")]
    public string PriceUsd { get; set; } = string.Empty;
    
    [JsonPropertyName("time")]
    public long Time { get; set; } = 0;
}