using System.Text.Json.Serialization;
using Cryptocurrencies.Contracts.Models;

namespace Cryptocurrencies.Contracts.Responses;

public class GetCoinsResponse : CollectionResponseBase<CoinModel>
{ }