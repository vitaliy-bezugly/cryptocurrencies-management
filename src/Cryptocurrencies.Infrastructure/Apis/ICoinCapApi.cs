using Cryptocurrencies.Contracts.Responses;

namespace Cryptocurrencies.Infrastructure.Apis;

public interface ICoinCapApi
{
    Task<GetCoinsResponse> GetCoinsAsync();
    Task<GetCoinResponse> GetCoinByIdAsync(string id);
    Task<GetCoinHistoryResponse> GetCoinHistoryAsync(string id, string interval = "d1");
    Task<GetMarketsResponse> GetMarketsAsync(string id);
}