using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Cryptocurrencies.Application.Coins.GetAllCoinsQuery;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class CoinsViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private int _limit;
    private string _nameToFind;
    private ObservableCollection<CoinModel> _coins;

    public CoinsViewModel(IMediator mediator)
    {
        _mediator = mediator;
        
        _limit = 10;
        _nameToFind = string.Empty;
        _coins = GetInitialCoins();
    }

    public ObservableCollection<CoinModel> Coins
    {
        get => _coins;
        set => SetField(ref _coins, value);
    }
    
    public int Limit
    {
        get => _limit;
        set => SetField(ref _limit, value);
    }
    
    public string NameToFind
    {
        get => _nameToFind;
        set
        {
            SetField(ref _nameToFind, value);
            OrderCoins(_nameToFind);
        }
    }
    
    public async Task LoadCoinsAsync()
    {
        var coins = await _mediator.Send(new GetAllCoinsQuery(Limit));
        
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
                Id = "bitcoin", Name = "Bitcoin", Symbol = "BTC", Rank = 1, PriceUsd = 10000m,
                ChangePercent24Hr = 0.5d, MarketCapUsd = 100000000000m, Supply = 10000000d,
                MaxSupply = 21000000d, VolumeUsd24Hr = 1000000000m, Vwap24Hr = 10000m
            }
        };
    }
    
    private void OrderCoins(string filter)
    {
        var filteredCoins = Coins
            .OrderByDescending(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
        Coins.Clear();
        foreach (var coin in filteredCoins)
        {
            Coins.Add(coin);
        }
    }
}