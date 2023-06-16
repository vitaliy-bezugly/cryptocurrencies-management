using System.Text.Json.Serialization;

namespace Cryptocurrencies.Contracts.Responses;

public record GetAssetsResponse : ResponseBase<AssetResponse>
{
    public GetAssetsResponse(IReadOnlyCollection<AssetResponse> data, long timestamp) : base(data, timestamp)
    { }
}