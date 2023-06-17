using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetCoinQuery;

public record GetCoinQuery : IRequest<CoinModel>
{
    public GetCoinQuery(string id)
    {
        Id = id;
    }

    public string Id { get; init; }
}