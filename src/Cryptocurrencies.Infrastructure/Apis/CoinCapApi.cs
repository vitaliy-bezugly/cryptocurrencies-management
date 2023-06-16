using Cryptocurrencies.Contracts.Responses;

namespace Cryptocurrencies.Infrastructure.Apis;

public class CoinCapApi : ApiBase, ICoinCapApi
{
    public CoinCapApi(HttpClient httpClient) : base(httpClient)
    { }
    
    public async Task<GetAssetsResponse> GetAssetsAsync()
    {
        GetAssetsResponse response = await GetAsync<GetAssetsResponse>("https://api.coincap.io/v2/assets");
        return response;
    }
}