using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptocurrencies.Application.Coins.GetAllCoinsQuery;
using Cryptocurrencies.Application.Common.Models;
using Cryptocurrencies.DesktopUi.Commands;
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
        _coins = new ObservableCollection<CoinModel>();
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
            OrderCoins();
        }
    }
    
    public ICommand LoadCoinsCommand => new CommandHandler(async () =>
    {
        await LoadCoinsAsync();
    }, () => true);
    
    public async Task LoadCoinsAsync()
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