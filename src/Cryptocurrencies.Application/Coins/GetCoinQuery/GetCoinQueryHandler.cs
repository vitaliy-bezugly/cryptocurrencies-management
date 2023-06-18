using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetCoinQuery;

public class GetCoinQueryHandler : IRequestHandler<GetCoinQuery, CoinModel>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;
    
    public GetCoinQueryHandler(ICoinApi coinApi, IMapper mapper)
    {
        _coinApi = coinApi;
        _mapper = mapper;
    }

    public async Task<CoinModel> Handle(GetCoinQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetCoinByIdAsync(request.Id);
        return _mapper.Map<CoinModel>(response.Data);
    }
}