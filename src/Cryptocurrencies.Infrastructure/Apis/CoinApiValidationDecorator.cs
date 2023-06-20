using System.Net;
using Cryptocurrencies.Application.Common.Interfaces;
using Cryptocurrencies.Contracts.Responses;

namespace Cryptocurrencies.Infrastructure.Apis;

public class CoinApiValidationDecorator : ICoinApi
{
    private readonly ICoinApi _coinApi;

    public CoinApiValidationDecorator(ICoinApi coinApi)
    {
        _coinApi = coinApi;
    }

    public async Task<GetCoinsResponse> GetCoinsAsync(int limit = 10)
    {
        var result = await _coinApi.GetCoinsAsync(limit);
        EnsureDataIsNotNullOrThrowException(result.Data);
        return result;
    }

    public async Task<GetCoinResponse> GetCoinByIdAsync(string id)
    {
        var result = await _coinApi.GetCoinByIdAsync(id);
        EnsureDataIsNotNullOrThrowException(result.Data);
        return result;
    }

    public async  Task<GetCoinHistoryResponse> GetCoinHistoryAsync(string id, string interval = "d1")
    {
        var result = await _coinApi.GetCoinHistoryAsync(id, interval);
        EnsureDataIsNotNullOrThrowException(result.Data);
        return result;
    }

    public async Task<GetMarketsResponse> GetMarketsAsync(string coinId, int limit = 10)
    {
        var result = await _coinApi.GetMarketsAsync(coinId, limit);
        EnsureDataIsNotNullOrThrowException(result.Data);
        return result;
    }

    public async Task<GetRatesResponse> GetRatesAsync()
    {
        var result = await _coinApi.GetRatesAsync();
        EnsureDataIsNotNullOrThrowException(result.Data);
        return result;
    }

    public async Task<GetRateResponse> GetRateByIdAsync(string id)
    {
        var result = await _coinApi.GetRateByIdAsync(id);
        EnsureDataIsNotNullOrThrowException(result.Data);
        return result;
    }
    
    private void EnsureDataIsNotNullOrThrowException<T>(T data)
    {
        if (data is null)
        {
            throw new HttpRequestException("Data is null. There is no such resource", new Exception(), 
                HttpStatusCode.NotFound);
        }
    }
}