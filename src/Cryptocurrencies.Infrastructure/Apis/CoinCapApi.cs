using Cryptocurrencies.Contracts.Responses;

namespace Cryptocurrencies.Infrastructure.Apis;

public class CoinCapApi : ApiBase, ICoinCapApi
{
    public CoinCapApi(HttpClient httpClient) : base(httpClient)
    { }
    
    public async Task<GetCoinsResponse> GetCoinsAsync()
    {
        GetCoinsResponse collectionResponse = await GetAsync<GetCoinsResponse>("https://api.coincap.io/v2/assets");
        return collectionResponse;
    }

    public async Task<GetCoinResponse> GetCoinByIdAsync(string id)
    {
        GetCoinResponse response = await GetAsync<GetCoinResponse>($"https://api.coincap.io/v2/assets/{id}");
        return response;
    }

    public async Task<GetCoinHistoryResponse> GetCoinHistoryAsync(string id, string interval = "d1")
    {
        GetCoinHistoryResponse response = await GetAsync<GetCoinHistoryResponse>
            ($"https://api.coincap.io/v2/assets/{id}/history?interval=d1");
        return response;
    }

    public async Task<GetMarketsResponse> GetMarketsAsync(string id)
    {
        GetMarketsResponse response = await GetAsync<GetMarketsResponse>($"https://api.coincap.io/v2/assets/{id}/markets");
        return response;
    }

    public async Task<GetRatesResponse> GetRatesAsync()
    {
        GetRatesResponse response = await GetAsync<GetRatesResponse>("https://api.coincap.io/v2/rates");
        return response;
    }

    public async Task<GetRateResponse> GetRateByIdAsync(string id)
    {
        GetRateResponse response = await GetAsync<GetRateResponse>($"https://api.coincap.io/v2/rates/{id}");
        return response;
    }
}