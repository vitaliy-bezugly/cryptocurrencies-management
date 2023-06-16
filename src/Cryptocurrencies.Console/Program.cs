using Cryptocurrencies.Contracts.Responses;
using Cryptocurrencies.Infrastructure.Apis;

ICoinCapApi api = new CoinCapApi(new HttpClient());
GetAssetsResponse response = await api.GetAssetsAsync();

foreach (var item in response.Data)
{
    Console.WriteLine(item);
}

Console.WriteLine($"Timestamp: {response.Timestamp}");