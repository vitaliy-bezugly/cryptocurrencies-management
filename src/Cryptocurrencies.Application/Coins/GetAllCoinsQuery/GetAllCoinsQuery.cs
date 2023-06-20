using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetAllCoinsQuery;

public record GetAllCoinsQuery : IRequest<IReadOnlyCollection<CoinModel>>
{
    public GetAllCoinsQuery(int limit)
    {
        Limit = limit > 2000 || limit < 0 ? 10 : limit;
    }

    public int Limit { get; init; }
}