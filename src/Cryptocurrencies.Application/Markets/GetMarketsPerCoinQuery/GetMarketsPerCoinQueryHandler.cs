using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Markets.GetMarketsPerCoinQuery;

public class GetMarketsPerCoinQueryHandler : IRequestHandler<GetMarketsPerCoinQuery, IReadOnlyCollection<MarketModel>>
{
    private readonly ICoinApi _coinApi;

    public GetMarketsPerCoinQueryHandler(ICoinApi coinApi)
    {
        _coinApi = coinApi;
    }

    public async Task<IReadOnlyCollection<MarketModel>> Handle(GetMarketsPerCoinQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetMarketsAsync(request.CoinId, request.Limit);
        return response.Data;
    }
}