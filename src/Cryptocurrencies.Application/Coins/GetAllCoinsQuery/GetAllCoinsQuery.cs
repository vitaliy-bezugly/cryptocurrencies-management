using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetAllCoinsQuery;

public record GetAllCoinsQuery : IRequest<IReadOnlyCollection<CoinModel>>
{
    public GetAllCoinsQuery(int limit)
    {
        Limit = limit;
    }

    public int Limit { get; init; }
}