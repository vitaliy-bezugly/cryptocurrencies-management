using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetCoinHistoryQuery;

public class GetCoinHistoryHandler : IRequestHandler<GetCoinHistoryQuery, IReadOnlyCollection<CoinHistoryModel>>
{
    private readonly ICoinApi _coinApi;

    public GetCoinHistoryHandler(ICoinApi coinApi)
    {
        _coinApi = coinApi;
    }

    public async Task<IReadOnlyCollection<CoinHistoryModel>> Handle(GetCoinHistoryQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetCoinHistoryAsync(request.Id, request.Interval);
        return response.Data;
    }
}