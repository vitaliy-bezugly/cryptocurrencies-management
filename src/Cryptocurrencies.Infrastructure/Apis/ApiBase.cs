using System.Text.Json;

namespace Cryptocurrencies.Infrastructure.Apis;

public abstract class ApiBase
{
    private readonly HttpClient _httpClient;

    protected ApiBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    protected async Task<T> GetAsync<T>(string url, int? limit = null)
    {
        if(limit is not null)
            url += "?limit=" + limit;
        
        var response = await _httpClient.GetAsync(url);
        
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content)!;
    }
}