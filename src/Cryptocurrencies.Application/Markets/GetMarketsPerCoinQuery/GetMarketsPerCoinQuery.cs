using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Markets.GetMarketsPerCoinQuery;

public record GetMarketsPerCoinQuery : IRequest<IReadOnlyCollection<MarketModel>>
{
    public GetMarketsPerCoinQuery(string coinId, int limit = 10)
    {
        CoinId = coinId;
        Limit = limit;
    }

    public string CoinId { get; init; }
    public int Limit { get; init; }
}