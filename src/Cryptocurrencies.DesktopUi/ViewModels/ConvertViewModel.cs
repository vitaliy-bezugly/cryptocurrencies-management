using System.Globalization;
using System.Threading.Tasks;
using Cryptocurrencies.Application.Rates.GetRateByIdQuery;
using MediatR;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class ConvertViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private string _fromCurrency;
    private string _amountOfDollars;
    private string _amountOfCurrency;
    
    public ConvertViewModel(IMediator mediator)
    {
        _mediator = mediator;
        
        _fromCurrency = "ukrainian-hryvnia";
        _amountOfDollars = "Undefined";
        _amountOfCurrency = "1";
    }

    public async Task ConvertAsync()
    {
        var rate = await _mediator.Send(new GetRateByIdQuery(_fromCurrency));
        
        // TODO: add it into Mediatr
        AmountOfDollars = (decimal.Parse(AmountOfCurrency) * decimal.Parse(rate.RateUsd))
            .ToString(CultureInfo.InvariantCulture);
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
    
    public string AmountOfDollars
    {
        get => _amountOfDollars;
        set
        {
            _amountOfDollars = value;
            OnPropertyChanged();
        }
    }
    
    public string AmountOfCurrency
    {
        get => _amountOfCurrency;
        set
        {
            _amountOfCurrency = value;
            OnPropertyChanged();
        }
    }
}