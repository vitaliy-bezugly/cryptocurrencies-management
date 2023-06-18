using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cryptocurrencies.Application.Coins.GetCoinQuery;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class CurrencyViewModel : INotifyPropertyChanged
{
    private readonly IMediator _mediator;
    private CoinModel _model;
    private string _currencyId;

    public CurrencyViewModel(IMediator mediator)
    {
        _mediator = mediator;
        
        _model = new CoinModel();
        _currencyId = String.Empty;
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
    
    public async Task FindCurrencyByIdAsync()
    {
        var coin = await _mediator.Send(new GetCoinQuery(_currencyId));
        Currency = coin;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}