using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cryptocurrencies.Application.Coins.GetAllCoinsQuery;
using Cryptocurrencies.Application.Common.Models;
using MediatR;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class CoinsViewModel : INotifyPropertyChanged
{
    private readonly IMediator _mediator;
    private ObservableCollection<CoinModel> _coins;
    
    public CoinsViewModel(IMediator mediator)
    {
        _mediator = mediator;

        _coins = new ObservableCollection<CoinModel>();
    }

    public ObservableCollection<CoinModel> Coins
    {
        get => _coins;
        set
        {
            _coins = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Coins)));
        }
    }
    
    public async Task LoadCoinsAsync()
    {
        var coins = await _mediator.Send(new GetAllCoinsQuery(10));
        Coins.Clear();

        foreach (var coin in coins)
        {
            Coins.Add(coin);
        }
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