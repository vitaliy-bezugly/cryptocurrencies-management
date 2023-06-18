using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record CoinModel : IMapFrom<CoinDto>
{
    public string Id { get; init; } = string.Empty;
    
    public int Rank { get; init; }
    
    public string Symbol { get; init; } = string.Empty;
    
    public string Name { get; init; } = string.Empty;
    
    public double Supply { get; init; }
    
    public double MaxSupply { get; init; }
    
    public decimal MarketCapUsd { get; init; }
    
    public decimal VolumeUsd24Hr { get; init; }
    
    public decimal PriceUsd { get; init; }
    
    public double ChangePercent24Hr { get; init; }
    
    public decimal Vwap24Hr { get; init; }
}