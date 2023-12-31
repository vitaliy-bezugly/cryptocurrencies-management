using System.Net;
using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Markets.GetMarketsPerCoinQuery;

public class GetMarketsPerCoinQueryHandler : IRequestHandler<GetMarketsPerCoinQuery, IReadOnlyCollection<MarketModel>>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;
    public GetMarketsPerCoinQueryHandler(ICoinApi coinApi, IMapper mapper)
    {
        _coinApi = coinApi;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<MarketModel>> Handle(GetMarketsPerCoinQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetMarketsAsync(request.CoinId, request.Limit);
        return _mapper.Map<List<MarketModel>>(response.Data);
    }
}