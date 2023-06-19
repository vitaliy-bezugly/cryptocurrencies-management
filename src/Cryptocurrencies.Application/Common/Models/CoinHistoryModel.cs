using Cryptocurrencies.Application.Common.Mappings;
using Cryptocurrencies.Contracts.Dtos;

namespace Cryptocurrencies.Application.Common.Models;

public record CoinHistoryModel : IMapFrom<CoinHistoryDto>
{
    public double PriceUsd { get; init; }

    public long Time { get; init; } = 0;
}