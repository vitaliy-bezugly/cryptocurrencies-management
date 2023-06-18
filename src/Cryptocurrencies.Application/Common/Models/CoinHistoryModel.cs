using System.Text.Json.Serialization;
using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record CoinHistoryModel : IMapFrom<CoinHistoryDto>
{
    public string PriceUsd { get; init; } = string.Empty;
    
    public long Time { get; init; } = 0;
}