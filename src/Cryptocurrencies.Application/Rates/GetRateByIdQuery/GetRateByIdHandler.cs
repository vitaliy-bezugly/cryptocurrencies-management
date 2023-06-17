using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.GetRateByIdQuery;

public class GetRateByIdHandler : IRequestHandler<GetRateByIdQuery, RateModel>
{
    private readonly ICoinApi _coinApi;

    public GetRateByIdHandler(ICoinApi coinApi)
    {
        _coinApi = coinApi;
    }

    public async Task<RateModel> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetRateByIdAsync(request.CurrencyId);
        return response.Data;
    }
}