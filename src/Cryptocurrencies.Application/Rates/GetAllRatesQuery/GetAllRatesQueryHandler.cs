using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.GetAllRatesQuery;

public class GetAllRatesQueryHandler : IRequestHandler<GetAllRatesQuery, IReadOnlyCollection<RateModel>>
{
    private readonly ICoinApi _coinApi;

    public GetAllRatesQueryHandler(ICoinApi coinApi)
    {
        _coinApi = coinApi;
    }

    public async Task<IReadOnlyCollection<RateModel>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetRatesAsync();
        return response.Data;
    }
}