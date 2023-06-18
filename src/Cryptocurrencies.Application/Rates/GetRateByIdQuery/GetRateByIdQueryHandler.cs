using AutoMapper;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.GetRateByIdQuery;

public class GetRateByIdQueryHandler : IRequestHandler<GetRateByIdQuery, RateModel>
{
    private readonly ICoinApi _coinApi;
    private readonly IMapper _mapper;
    
    public GetRateByIdQueryHandler(ICoinApi coinApi, IMapper mapper)
    {
        _coinApi = coinApi;
        _mapper = mapper;
    }

    public async Task<RateModel> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _coinApi.GetRateByIdAsync(request.CurrencyId);
        return _mapper.Map<RateModel>(response.Data);
    }
}