using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Responses;
using Cryptocurrencies.Infrastructure.Routes;

namespace Cryptocurrencies.Infrastructure.Apis;

public class CoinCapApi : ApiBase, ICoinApi
{
    public CoinCapApi(HttpClient httpClient) : base(httpClient)
    { }
    
    public async Task<GetCoinsResponse> GetCoinsAsync(int limit = 10)
    {
        GetCoinsResponse collectionResponse = await GetAsync<GetCoinsResponse>(ApiRoutes.CoinCap.Coins, limit);
        return collectionResponse;
    }

    public async Task<GetCoinResponse> GetCoinByIdAsync(string id)
    {
        GetCoinResponse response = await GetAsync<GetCoinResponse>(ApiRoutes.CoinCap.Coin.Replace("{id}", id));
        return response;
    }

    public async Task<GetCoinHistoryResponse> GetCoinHistoryAsync(string id, string interval = "d1")
    {
        GetCoinHistoryResponse response = await GetAsync<GetCoinHistoryResponse>
            (ApiRoutes.CoinCap.CoinHistory.Replace("{id}", id) + $"?interval={interval}");
        return response;
    }

    public async Task<GetMarketsResponse> GetMarketsAsync(string id)
    {
        GetMarketsResponse response = await GetAsync<GetMarketsResponse>(ApiRoutes.CoinCap.Markets.Replace("{id}", id));
        return response;
    }

    public async Task<GetRatesResponse> GetRatesAsync()
    {
        GetRatesResponse response = await GetAsync<GetRatesResponse>(ApiRoutes.CoinCap.Rates);
        return response;
    }

    public async Task<GetRateResponse> GetRateByIdAsync(string id)
    {
        GetRateResponse response = await GetAsync<GetRateResponse>(ApiRoutes.CoinCap.Rate.Replace("{id}", id));
        return response;
    }
}