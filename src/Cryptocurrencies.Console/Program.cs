using Cryptocurrencies.Infrastructure.Apis;

ICoinCapApi api = new CoinCapApi(new HttpClient());
var response = await api.GetRateByIdAsync("ethereum");

Console.WriteLine(response.Data);
Console.WriteLine($"Timestamp: {response.Timestamp}");