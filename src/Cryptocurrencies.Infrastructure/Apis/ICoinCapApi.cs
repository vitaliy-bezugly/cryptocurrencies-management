using Cryptocurrencies.Contracts.Responses;

namespace Cryptocurrencies.Infrastructure.Apis;

public interface ICoinCapApi
{
    Task<GetAssetsResponse> GetAssetsAsync();
}