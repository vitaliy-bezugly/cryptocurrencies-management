using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Coins.GetAllCoinsQuery;

public class GetAllCoinsQueryHandler : IRequestHandler<GetAllCoinsQuery, IReadOnlyCollection<CoinModel>>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;
    
    public GetAllCoinsQueryHandler(ICoinApi coinApi, IMapper mapper)
    {
        _coinApi = coinApi;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<CoinModel>> Handle(GetAllCoinsQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetCoinsAsync(request.Limit);
        return _mapper.Map<List<CoinModel>>(response.Data);
    }
}