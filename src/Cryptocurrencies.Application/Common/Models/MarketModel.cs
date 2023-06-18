using System.Text.Json.Serialization;
using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record MarketModel : IMapFrom<MarketDto>
{
    public string ExchangeId { get; init; } = string.Empty;
    
    public string BaseId { get; init; } = string.Empty;
    
    public string QuoteId { get; init; } = string.Empty;
    
    public string BaseSymbol { get; init; } = string.Empty;
    
    public string QuoteSymbol { get; init; } = string.Empty;
    
    public string VolumeUsd24Hr { get; init; } = string.Empty;

    public string PriceUsd { get; init; } = String.Empty;
    
    public string VolumePercent { get; init; } = string.Empty;
}