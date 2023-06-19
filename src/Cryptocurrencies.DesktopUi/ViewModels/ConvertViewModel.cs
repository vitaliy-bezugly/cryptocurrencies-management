using System.Threading.Tasks;
using Cryptocurrencies.Application.Rates.GetRateByIdQuery;
using MediatR;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class ConvertViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    private string _fromCurrency;
    private double _amountOfDollars;
    private double _amountOfCurrency;
    
    public ConvertViewModel(IMediator mediator)
    {
        _mediator = mediator;
        
        _fromCurrency = "ukrainian-hryvnia";
        _amountOfDollars = 0d;
        _amountOfCurrency = 1d;
    }

    public async Task ConvertAsync()
    {
        var rate = await _mediator.Send(new GetRateByIdQuery(_fromCurrency));
        
        // TODO: add it into Mediatr
        AmountOfDollars = AmountOfCurrency * rate.RateUsd;
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
    
    public double AmountOfDollars
    {
        get => _amountOfDollars;
        set
        {
            _amountOfDollars = value;
            OnPropertyChanged();
        }
    }
    
    public double AmountOfCurrency
    {
        get => _amountOfCurrency;
        set
        {
            _amountOfCurrency = value;
            OnPropertyChanged();
        }
    }
}