using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.ConvertRateQuery;

public class ConvertRateQueryHandler : IRequestHandler<ConvertRateQuery, double>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;

    public ConvertRateQueryHandler(ICoinApi coinApi, IMapper mapper)
    {
        _coinApi = coinApi;
        _mapper = mapper;
    }

    public async Task<double> Handle(ConvertRateQuery request, CancellationToken cancellationToken)
    {
        var fromCoinResponse = await _coinApi.GetRateByIdAsync(request.FromCoinId);
        var toCoinResponse = await _coinApi.GetRateByIdAsync(request.ToCoinId);

        var fromCoin = _mapper.Map<RateModel>(fromCoinResponse.Data);
        var toCoin = _mapper.Map<RateModel>(toCoinResponse.Data);
        
        return request.Amount * fromCoin.RateUsd / toCoin.RateUsd;
    }
}