using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptocurrencies.Application.Coins.GetCoinHistoryQuery;
using Cryptocurrencies.Application.Coins.GetCoinQuery;
using Cryptocurrencies.Application.Common.Exceptions;
using Cryptocurrencies.Application.Common.Models;
using Cryptocurrencies.Application.Markets.GetMarketsPerCoinQuery;
using Cryptocurrencies.DesktopUi.Commands;
using Cryptocurrencies.DesktopUi.Constants;
using Cryptocurrencies.DesktopUi.DIItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class CoinViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CoinViewModel> _logger;
    private CoinModel _currency;
    private string _currencyId;
    private ObservableCollection<MarketModel> _markets;
    private ObservableCollection<CoinHistoryModel> _history;
    private string _findCoinGearVisibility;
    private string _loadHistoryGearVisibility;
    private string _loadMarketsGearVisibility;

    public CoinViewModel(IMediator mediator, ILogger<CoinViewModel> logger, ICoinContainer coinContainer)
    {
        _mediator = mediator;
        _logger = logger;

        // for fix warnings
        _currencyId = string.Empty;
        _currency = new CoinModel();
        
        Currency = coinContainer.Coin;
        CurrencyId = coinContainer.Coin.Id;
        
        _markets = new ObservableCollection<MarketModel>();
        _history = new ObservableCollection<CoinHistoryModel>();

        _findCoinGearVisibility = Elements.Visibility.Hidden;
        _loadMarketsGearVisibility = Elements.Visibility.Hidden;
        _loadHistoryGearVisibility = Elements.Visibility.Hidden;
    }

    public CoinModel Currency
    {
        get => _currency;
        set => SetField(ref _currency, value);
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
    
    public string FindCoinGearVisibility
    {
        get => _findCoinGearVisibility;
        set => SetField(ref _findCoinGearVisibility, value);
    }
    
    public string LoadMarketsGearVisibility
    {
        get => _loadMarketsGearVisibility;
        set => SetField(ref _loadMarketsGearVisibility, value);
    }
    
    public string LoadHistoryGearVisibility
    {
        get => _loadHistoryGearVisibility;
        set => SetField(ref _loadHistoryGearVisibility, value);
    }
    
    public ICommand FindCurrencyCommand => new UnParametrizedCommandHandler(async () =>
    {
        FindCoinGearVisibility = Elements.Visibility.Visible;
        await FindCoinByIdAsync();
        FindCoinGearVisibility = Elements.Visibility.Hidden;
    }, () => string.IsNullOrEmpty(CurrencyId) == false);

    public ICommand LoadMarketsCommand => new UnParametrizedCommandHandler(async () =>
    {
        LoadMarketsGearVisibility = Elements.Visibility.Visible;
        await FindMarketsByCurrencyIdAsync();
        LoadMarketsGearVisibility = Elements.Visibility.Hidden;
    }, () => string.IsNullOrEmpty(CurrencyId) == false);
    
    public ICommand LoadHistoryCommand => new UnParametrizedCommandHandler(async () =>
    {
        LoadHistoryGearVisibility = Elements.Visibility.Visible;
        await FindHistoryByCurrencyIdAsync();
        LoadHistoryGearVisibility = Elements.Visibility.Hidden;
    }, () => string.IsNullOrEmpty(CurrencyId) == false);

    private async Task FindCoinByIdAsync()
    {
        try
        {
            var coin = await _mediator.Send(new GetCoinQuery(_currencyId));
            Currency = coin;
        }
        catch (NotFoundException e)
        {
            Currency = new CoinModel
            {
                Name = "Not found"
            };
            
            _logger.LogWarning(e.Message);
        }
    }
    
    private async Task FindMarketsByCurrencyIdAsync()
    {
        try
        {
            var markets = await _mediator.Send(new GetMarketsPerCoinQuery(_currencyId));
        
            Markets.Clear();
            foreach (var market in markets)
            {
                Markets.Add(market);
            }
        }
        catch (NotFoundException e)
        {
            Markets.Clear();
            Markets.Add(new MarketModel
            {
                QuoteId = "Undefined", ExchangeId = "Not found", PriceUsd = 0d
            });
            
            _logger.LogWarning(e.Message);
        }
    }
    
    private async Task FindHistoryByCurrencyIdAsync()
    {
        try
        {
            var history = await _mediator.Send(new GetCoinHistoryQuery(_currencyId, "d1"));
        
            History.Clear();
            foreach (var coinHistoryModel in history.OrderByDescending(x => x.Time))
            {
                History.Add(coinHistoryModel);
            }
        }
        catch (NotFoundException e)
        {
            History.Clear();
            History.Add(new CoinHistoryModel
            {
                Time = DateTime.Now, PriceUsd = 0d
            });
            
            _logger.LogWarning(e.Message);
        }
    }
}