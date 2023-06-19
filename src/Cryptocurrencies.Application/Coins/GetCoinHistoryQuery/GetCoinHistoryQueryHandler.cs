using System.Net;
using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetCoinHistoryQuery;

public class GetCoinHistoryQueryHandler : IRequestHandler<GetCoinHistoryQuery, IReadOnlyCollection<CoinHistoryModel>>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;
    
    public GetCoinHistoryQueryHandler(ICoinApi coinApi, IMapper mapper)
    {
        _coinApi = coinApi;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<CoinHistoryModel>> Handle(GetCoinHistoryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _coinApi.GetCoinHistoryAsync(request.Id, request.Interval);
            return _mapper.Map<List<CoinHistoryModel>>(response.Data);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<CoinHistoryModel> { new CoinHistoryModel { PriceUsd = 0, Time = DateTime.MinValue } };    
            }
            
            throw;
        }
    }
}