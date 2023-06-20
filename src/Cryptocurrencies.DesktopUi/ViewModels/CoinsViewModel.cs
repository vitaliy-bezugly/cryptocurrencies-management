using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptocurrencies.Application.Coins.GetAllCoinsQuery;
using Cryptocurrencies.Application.Common.Models;
using Cryptocurrencies.DesktopUi.Commands;
using Cryptocurrencies.DesktopUi.Constants;
using Cryptocurrencies.DesktopUi.DIItems;
using Cryptocurrencies.DesktopUi.Views;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class CoinsViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private readonly IFrameContainer _frameContainer;
    private readonly ICoinContainer _coinContainer;
    private readonly ILogger<CoinViewModel> _coinViewModelLogger;
    
    private ObservableCollection<CoinModel> _coins;
    private int _limit;
    private string _nameToFind;
    private string _gearVisibility;

    public CoinsViewModel(IMediator mediator, IFrameContainer frameContainer, ICoinContainer coinContainer, ILogger<CoinViewModel> coinViewModelLogger)
    {
        _mediator = mediator;
        _frameContainer = frameContainer;
        _coinContainer = coinContainer;
        _coinViewModelLogger = coinViewModelLogger;

        _limit = 10;
        _nameToFind = string.Empty;
        _coins = new ObservableCollection<CoinModel>();
        _gearVisibility = Elements.Visibility.Hidden;
    }
    
    public ObservableCollection<CoinModel> Coins
    {
        get => _coins;
        set => SetField(ref _coins, value);
    }
    
    public int Limit
    {
        get => _limit;
        set
        {
            if (value > 2000)
                SetField(ref _limit, 2000);
            else
                SetField(ref _limit, value);
        }
    }
    
    public string GearVisibility
    {
        get => _gearVisibility;
        set => SetField(ref _gearVisibility, value);
    }
    
    public string NameToFind
    {
        get => _nameToFind;
        set
        {
            SetField(ref _nameToFind, value);
            OrderCoins();
        }
    }
    
    public ICommand LoadCoinsCommand => new UnParametrizedCommandHandler(async () =>
    {
        GearVisibility = Elements.Visibility.Visible;
        await LoadCoinsAsync();
        GearVisibility = Elements.Visibility.Hidden;
    }, () => true);

    public ICommand GoToCoinCommand => new ParametrizedCommandHandler((obj) =>
    {
        if (obj is null)
            return;
        string coinId = (string)obj;
        
        _coinContainer.Coin = Coins.First(x => x.Id == coinId);
        _frameContainer.NavigationFrame.NavigationService
            .Navigate(new CoinPage(new CoinViewModel(_mediator, _coinViewModelLogger, _coinContainer)));
    }, obj => obj is not null && obj is string);

    private async Task LoadCoinsAsync()
    {
        var coins = await _mediator.Send(new GetAllCoinsQuery(Limit));
        
        Coins.Clear();
        foreach (var coin in coins)
        {
            Coins.Add(coin);
        }
    }
    
    private void OrderCoins()
    {
        var filteredCoins = Coins
            .OrderByDescending(c => c.Name.Contains(NameToFind, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
        Coins.Clear();
        foreach (var coin in filteredCoins)
        {
            Coins.Add(coin);
        }
    }
}