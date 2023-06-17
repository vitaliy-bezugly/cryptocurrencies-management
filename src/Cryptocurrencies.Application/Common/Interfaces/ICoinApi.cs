using Cryptocurrencies.Contracts.Responses;

namespace Cryptocurrencies.Application.Common.Interfaces;

public interface ICoinApi
{
    Task<GetCoinsResponse> GetCoinsAsync();
    Task<GetCoinResponse> GetCoinByIdAsync(string id);
    Task<GetCoinHistoryResponse> GetCoinHistoryAsync(string id, string interval = "d1");
    Task<GetMarketsResponse> GetMarketsAsync(string id);
    Task<GetRatesResponse> GetRatesAsync();
    Task<GetRateResponse> GetRateByIdAsync(string id);
}