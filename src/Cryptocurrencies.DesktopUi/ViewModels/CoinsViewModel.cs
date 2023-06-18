using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cryptocurrencies.Application.Coins.GetAllCoinsQuery;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class CoinsViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private ObservableCollection<CoinModel> _coins;
    
    public CoinsViewModel(IMediator mediator)
    {
        _mediator = mediator;

        _coins = GetInitialCoins();
    }

    public ObservableCollection<CoinModel> Coins
    {
        get => _coins;
        set => SetField(ref _coins, value);
    }
    
    public async Task LoadCoinsAsync()
    {
        var coins = await _mediator.Send(new GetAllCoinsQuery(10));
        
        Coins.Clear();
        foreach (var coin in coins)
        {
            Coins.Add(coin);
        }
    }
    
    private ObservableCollection<CoinModel> GetInitialCoins()
    {
        return new ObservableCollection<CoinModel>
        {
            new CoinModel
            {
                Id = "bitcoin", Name = "Bitcoin", Symbol = "BTC", Rank = "1", PriceUsd = "10000",
                ChangePercent24Hr = "0.5", MarketCapUsd = "100000000000", Supply = "10000000",
                MaxSupply = "21000000", VolumeUsd24Hr = "1000000000", Vwap24Hr = "10000"
            }
        };
    }
}