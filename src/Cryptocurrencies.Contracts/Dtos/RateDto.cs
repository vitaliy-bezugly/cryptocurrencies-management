using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Dtos;

public class RateDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;
    
    [JsonPropertyName("symbol")]
    public string Symbol { get; init; } = string.Empty;
    
    [JsonPropertyName("currencySymbol")]
    public string CurrencySymbol { get; init; } = string.Empty;
    
    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;
    
    [JsonPropertyName("rateUsd")]
    public string RateUsd { get; init; } = string.Empty;
}