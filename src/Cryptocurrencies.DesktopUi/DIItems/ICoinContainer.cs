using Cryptocurrencies.Application.Common.Models;

namespace Cryptocurrencies.DesktopUi.DIItems;

public interface ICoinContainer
{
    public CoinModel Coin { get; set; }
}