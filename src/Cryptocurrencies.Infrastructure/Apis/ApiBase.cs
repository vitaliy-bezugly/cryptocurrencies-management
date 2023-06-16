using System.Text.Json;

namespace Cryptocurrencies.Infrastructure.Apis;

public abstract class ApiBase : IDisposable
{
    private readonly HttpClient _httpClient;

    protected ApiBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    protected async Task<T> GetAsync<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}