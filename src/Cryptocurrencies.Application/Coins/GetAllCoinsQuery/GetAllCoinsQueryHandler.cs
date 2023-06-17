using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetAllCoinsQuery;

public class GetAllCoinsQueryHandler : IRequestHandler<GetAllCoinsQuery, IReadOnlyCollection<CoinModel>>
{
    private readonly ICoinApi _coinApi;

    public GetAllCoinsQueryHandler(ICoinApi coinApi)
    {
        _coinApi = coinApi;
    }

    public async Task<IReadOnlyCollection<CoinModel>> Handle(GetAllCoinsQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetCoinsAsync(request.Limit);
        return response.Data;
    }
}