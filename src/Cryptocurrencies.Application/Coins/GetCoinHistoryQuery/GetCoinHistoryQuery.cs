using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetCoinHistoryQuery;

public record GetCoinHistoryQuery : IRequest<IReadOnlyCollection<CoinHistoryModel>>
{
    public GetCoinHistoryQuery(string id, string interval)
    {
        Id = id;
        Interval = interval;
    }

    public string Id { get; init; }
    public string Interval { get; init; }
}