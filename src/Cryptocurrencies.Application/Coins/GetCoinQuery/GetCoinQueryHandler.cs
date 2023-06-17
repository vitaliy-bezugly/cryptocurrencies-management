using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetCoinQuery;

public class GetCoinQueryHandler : IRequestHandler<GetCoinQuery, CoinModel>
{
    private readonly ICoinApi _api;

    public GetCoinQueryHandler(ICoinApi api)
    {
        _api = api;
    }

    public async Task<CoinModel> Handle(GetCoinQuery request, CancellationToken cancellationToken)
    {
        var response = await _api.GetCoinByIdAsync(request.Id);
        return response.Data;
    }
}