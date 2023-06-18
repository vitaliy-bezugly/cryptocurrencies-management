using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.GetAllRatesQuery;

public class GetAllRatesQueryHandler : IRequestHandler<GetAllRatesQuery, IReadOnlyCollection<RateModel>>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;
    
    public GetAllRatesQueryHandler(ICoinApi coinApi, IMapper mapper)
    {
        _coinApi = coinApi;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<RateModel>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetRatesAsync();
        return _mapper.Map<List<RateModel>>(response.Data);
    }
}