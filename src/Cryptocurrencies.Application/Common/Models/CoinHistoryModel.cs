using System.Text.Json.Serialization;
using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record CoinHistoryModel : IMapFrom<CoinHistoryDto>
{
    [JsonPropertyName("priceUsd")]
    public string PriceUsd { get; set; } = string.Empty;
    
    [JsonPropertyName("time")]
    public long Time { get; set; } = 0;
}