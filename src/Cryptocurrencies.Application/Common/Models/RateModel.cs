using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record RateModel : IMapFrom<RateDto>
{
    public string Id { get; init; } = string.Empty;
    
    public string Symbol { get; init; } = string.Empty;
    
    public string CurrencySymbol { get; init; } = string.Empty;
    
    public string Type { get; init; } = string.Empty;
    
    public double RateUsd { get; init; }
}