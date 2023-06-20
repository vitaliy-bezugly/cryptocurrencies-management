using System.Windows.Input;
using Cryptocurrencies.DesktopUi.Commands;
using Cryptocurrencies.DesktopUi.DIItems;
using Cryptocurrencies.DesktopUi.Views;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IFrameContainer _frameContainer;
    private readonly CoinPage _coinPage;
    private readonly CoinsPage _coinsPage;
    private readonly ConvertPage _convertPage;

    public MainWindowViewModel(IFrameContainer frameContainerContainer, CoinPage coinPage, CoinsPage coinsPage, ConvertPage convertPage)
    {
        _frameContainer = frameContainerContainer;
        _coinPage = coinPage;
        _coinsPage = coinsPage;
        _convertPage = convertPage;
    }

    public ICommand GoToCurrencyCommand => new UnParametrizedCommandHandler(() =>
    {
        _frameContainer.NavigationFrame.NavigationService.Navigate(_coinPage);
    }, () => true);
    
    public ICommand GoToCoinsCommand => new UnParametrizedCommandHandler(() =>
    {
        _frameContainer.NavigationFrame.NavigationService.Navigate(_coinsPage);
    }, () => true);
    
    public ICommand GoToConvertCommand => new UnParametrizedCommandHandler(() =>
    {
        _frameContainer.NavigationFrame.NavigationService.Navigate(_convertPage);
    }, () => true);
}