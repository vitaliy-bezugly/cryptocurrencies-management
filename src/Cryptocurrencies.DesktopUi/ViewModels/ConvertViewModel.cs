using System.Threading.Tasks;
using System.Windows.Input;
using Cryptocurrencies.Application.Common.Exceptions;
using Cryptocurrencies.Application.Rates.ConvertRateQuery;
using Cryptocurrencies.DesktopUi.Commands;
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
    
    public ConvertViewModel(IMediator mediator, ILogger<CoinsViewModel> logger)
    {
        _mediator = mediator;
        _logger = logger;

        _fromCurrency = "ukrainian-hryvnia";
        _toCurrency = "united-states-dollar";
        _amount = 1d;
        _result = 0d;
    }

    public async Task ConvertAsync()
    {
        try
        {
            var result = await _mediator.Send(new ConvertRateQuery(Amount, FromCurrency, ToCurrency));
            Result = result;
        }
        catch (NotFoundException e)
        {
            Result = 0;
            _logger.LogWarning(e.Message);
        }
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
    
    public ICommand ConvertCommand => new CommandHandler(async () => await ConvertAsync(), 
        () => string.IsNullOrEmpty(FromCurrency) == false && string.IsNullOrEmpty(ToCurrency) == false);
}