using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Cryptocurrencies.Application.Common.Exceptions;
using Cryptocurrencies.Application.Common.Models;
using Cryptocurrencies.Application.Rates.ConvertRateQuery;
using Cryptocurrencies.Application.Rates.GetAllRatesQuery;
using Cryptocurrencies.DesktopUi.Commands;
using Cryptocurrencies.DesktopUi.Constants;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class ConvertViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CoinsViewModel> _logger;
    private string _fromCurrency;
    private string _toCurrency;
    private double _amount;
    private double _result;
    private string _convertGearVisibility;
    private string _getRatesGearVisibility;
    private ObservableCollection<RateModel> _rates;

    public ConvertViewModel(IMediator mediator, ILogger<CoinsViewModel> logger)
    {
        _mediator = mediator;
        _logger = logger;

        _fromCurrency = "ukrainian-hryvnia";
        _toCurrency = "united-states-dollar";
        _amount = 1d;
        _result = 0d;

        _rates = new ObservableCollection<RateModel>();

        _convertGearVisibility = Elements.Visibility.Hidden;
        _getRatesGearVisibility = Elements.Visibility.Hidden;
    }

    public string FromCurrency
    {
        get => _fromCurrency;
        set
        {
            _fromCurrency = value;
            OnPropertyChanged();
        }
    }
    
    public string ToCurrency
    {
        get => _toCurrency;
        set
        {
            _toCurrency = value;
            OnPropertyChanged();
        }
    }
    
    public double Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            OnPropertyChanged();
        }
    }
    
    public double Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<RateModel> Rates
    {
        get => _rates;
        set
        {
            _rates = value;
            OnPropertyChanged();
        }
    }
    
    public string ConvertGearVisibility
    {
        get => _convertGearVisibility;
        set
        {
            _convertGearVisibility = value;
            OnPropertyChanged();
        }
    }
    
    public string GetRatesGearVisibility
    {
        get => _getRatesGearVisibility;
        set
        {
            _getRatesGearVisibility = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand ConvertCommand => new UnParametrizedCommandHandler(async () =>
        {
            ConvertGearVisibility = Elements.Visibility.Visible;
            await ConvertAsync();
            ConvertGearVisibility = Elements.Visibility.Hidden;
        }, 
        () => string.IsNullOrEmpty(FromCurrency) == false && string.IsNullOrEmpty(ToCurrency) == false);

    public ICommand GetRatesCommand => new UnParametrizedCommandHandler(async () =>
    {
        GetRatesGearVisibility = Elements.Visibility.Visible;
        await GetRatesAsync();
        GetRatesGearVisibility = Elements.Visibility.Hidden;
    }, () => true);
    
    private async Task ConvertAsync()
    {
        try
        {
            var result = await _mediator.Send(new ConvertRateQuery(Amount, FromCurrency, ToCurrency));
            Result = result;
        }
        catch (NotFoundException e)
        {
            Result = -1;
            _logger.LogWarning(e.Message);
        }
    }

    private async Task GetRatesAsync()
    {
        var result = await _mediator.Send(new GetAllRatesQuery());
        
        Rates.Clear();
        foreach (var rate in result)
        {
            Rates.Add(rate);
        }
    }
}