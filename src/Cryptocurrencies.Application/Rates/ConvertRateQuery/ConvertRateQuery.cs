using MediatR;

namespace Cryptocurrencies.Application.Rates.ConvertRateQuery;

public record ConvertRateQuery : IRequest<double>
{
    public ConvertRateQuery(double amount, string fromCoinId, string toCoinId)
    {
        Amount = amount;
        FromCoinId = fromCoinId;
        ToCoinId = toCoinId;
    }

    public double Amount { get; init; }
    public string FromCoinId { get; init; }
    public string ToCoinId { get; init; }
}