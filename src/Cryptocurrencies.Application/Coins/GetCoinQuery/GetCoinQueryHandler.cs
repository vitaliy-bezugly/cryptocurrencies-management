using System.Net;
using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cryptocurrencies.Application.Coins.GetCoinQuery;

public class GetCoinQueryHandler : IRequestHandler<GetCoinQuery, CoinModel>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCoinQueryHandler> _logger;
    
    public GetCoinQueryHandler(ICoinApi coinApi, IMapper mapper, ILogger<GetCoinQueryHandler> logger)
    {
        _coinApi = coinApi;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CoinModel> Handle(GetCoinQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetCoinByIdAsync(request.Id);
        return _mapper.Map<CoinModel>(response.Data);
    }
}