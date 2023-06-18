using System.Text.Json.Serialization;
using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record CoinModel : IMapFrom<CoinDto>
{
    public string Id { get; init; } = string.Empty;
    
    public string Rank { get; init; } = string.Empty;
    
    public string Symbol { get; init; } = string.Empty;
    
    public string Name { get; init; } = string.Empty;
    
    public string Supply { get; init; } = string.Empty;
    
    public string MaxSupply { get; init; } = string.Empty;
    
    public string MarketCapUsd { get; init; } = string.Empty;
    
    public string VolumeUsd24Hr { get; init; } = string.Empty;
    
    public string PriceUsd { get; init; } = string.Empty;
    
    public string ChangePercent24Hr { get; init; } = string.Empty;
    
    public string Vwap24Hr { get; init; } = string.Empty;
}