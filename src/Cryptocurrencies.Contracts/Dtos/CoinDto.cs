using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Dtos;

public record CoinDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;
    
    [JsonPropertyName("rank")] 
    public string Rank { get; init; } = string.Empty;
    
    [JsonPropertyName("symbol")]
    public string Symbol { get; init; } = string.Empty;
    
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
    
    [JsonPropertyName("supply")]
    public string Supply { get; init; } = string.Empty;
    
    [JsonPropertyName("maxSupply")]
    public string MaxSupply { get; init; } = string.Empty;
    
    [JsonPropertyName("marketCapUsd")]
    public string MarketCapUsd { get; init; } = string.Empty;
    
    [JsonPropertyName("volumeUsd24Hr")]
    public string VolumeUsd24Hr { get; init; } = string.Empty;
    
    [JsonPropertyName("priceUsd")]
    public string PriceUsd { get; init; } = string.Empty;
    
    [JsonPropertyName("changePercent24Hr")] 
    public string ChangePercent24Hr { get; init; } = string.Empty;
    
    [JsonPropertyName("vwap24Hr")]
    public string Vwap24Hr { get; init; } = string.Empty;
}