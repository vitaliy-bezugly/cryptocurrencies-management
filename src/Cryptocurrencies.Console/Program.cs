using Cryptocurrencies.Infrastructure.Apis;

ICoinCapApi api = new CoinCapApi(new HttpClient());
var response = await api.GetMarketsAsync("ethereum");

foreach (var item in response.Data)
{
    Console.WriteLine(item);
}

Console.WriteLine($"Timestamp: {response.Timestamp}");