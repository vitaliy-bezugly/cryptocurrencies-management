using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptocurrencies.Application.Coins.GetCoinHistoryQuery;
using Cryptocurrencies.Application.Coins.GetCoinQuery;
using Cryptocurrencies.Application.Common.Models;
using Cryptocurrencies.Application.Markets.GetMarketsPerCoinQuery;
using Cryptocurrencies.DesktopUi.Commands;
using MediatR;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class CoinViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private CoinModel _model;
    private string _currencyId;
    private ObservableCollection<MarketModel> _markets;
    private ObservableCollection<CoinHistoryModel> _history;

    public CoinViewModel(IMediator mediator)
    {
        _mediator = mediator;

        _model = new CoinModel { Rank = 1, Name = "Unknown" };
        _currencyId = String.Empty;
        
        _markets = new ObservableCollection<MarketModel>();
        _history = new ObservableCollection<CoinHistoryModel>();
    }
    
    
    public async Task FindCoinByIdAsync()
    {
        var coin = await _mediator.Send(new GetCoinQuery(_currencyId));
        Currency = coin;
    }
    
    public async Task FindMarketsByCurrencyIdAsync()
    {
        var markets = await _mediator.Send(new GetMarketsPerCoinQuery(_currencyId));
        
        _markets.Clear();
        foreach (var market in markets)
        {
            _markets.Add(market);
        }
    }
    
    public async Task FindHistoryByCurrencyIdAsync()
    {
        var history = await _mediator.Send(new GetCoinHistoryQuery(_currencyId, "d1"));
        
        _history.Clear();
        foreach (var coinHistoryModel in history)
        {
            _history.Add(coinHistoryModel);
        }
    }
    
    public CoinModel Currency
    {
        get => _model;
        set => SetField(ref _model, value);
    }

    public string CurrencyId
    {
        get => _currencyId;
        set => SetField(ref _currencyId, value);
    }

    public ObservableCollection<MarketModel> Markets
    {
        get => _markets;
        set => SetField(ref _markets, value);
    }
    
    public ObservableCollection<CoinHistoryModel> History
    {
        get => _history;
        set => SetField(ref _history, value);
    }
    
    public ICommand FindCurrencyCommand => new CommandHandler(async () =>
    {
        await FindCoinByIdAsync();
    }, () => string.IsNullOrEmpty(CurrencyId) == false);

    public ICommand LoadMarketsCommand => new CommandHandler(async () =>
    {
        await FindMarketsByCurrencyIdAsync();
    }, () => string.IsNullOrEmpty(CurrencyId) == false);
    
    public ICommand LoadHistoryCommand => new CommandHandler(async () =>
    {
        await FindHistoryByCurrencyIdAsync();
    }, () => string.IsNullOrEmpty(CurrencyId) == false);
}