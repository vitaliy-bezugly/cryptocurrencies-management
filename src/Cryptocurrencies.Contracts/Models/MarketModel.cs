using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Models;

public record MarketModel
{
    [JsonPropertyName("exchangeId")]
    public string ExchangeId { get; set; } = string.Empty;
    
    [JsonPropertyName("baseId")]
    public string BaseId { get; set; } = string.Empty;
    
    [JsonPropertyName("quoteId")]
    public string QuoteId { get; set; } = string.Empty;
    
    [JsonPropertyName("baseSymbol")]
    public string BaseSymbol { get; set; } = string.Empty;
    
    [JsonPropertyName("quoteSymbol")]
    public string QuoteSymbol { get; set; } = string.Empty;
    
    [JsonPropertyName("volumeUsd24Hr")]
    public string VolumeUsd24Hr { get; set; } = string.Empty;
    
    [JsonPropertyName("volumePercent")]
    public string VolumePercent { get; set; } = string.Empty;
}