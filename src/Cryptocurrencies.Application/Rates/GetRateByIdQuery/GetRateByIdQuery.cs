using Cryptocurrencies.Contracts.Models;
using MediatR;

namespace Cryptocurrencies.Application.Rates.GetRateByIdQuery;

public record GetRateByIdQuery : IRequest<RateModel>
{
    public GetRateByIdQuery(string currencyId)
    {
        CurrencyId = currencyId;
    }

    public string CurrencyId { get; init; }
}