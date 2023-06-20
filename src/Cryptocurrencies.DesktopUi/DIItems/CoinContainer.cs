using Cryptocurrencies.Application.Common.Models;

namespace Cryptocurrencies.DesktopUi.DIItems;

public class CoinContainer : ICoinContainer
{
    public CoinModel Coin { get; set; }

    public CoinContainer()
    {
        Coin = new CoinModel
        {
            Rank = 0, Name = "Unknown"
        };
    }
}