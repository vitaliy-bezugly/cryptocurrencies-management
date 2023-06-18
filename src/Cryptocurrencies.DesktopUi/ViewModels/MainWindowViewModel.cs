using System.Windows.Input;
using Cryptocurrencies.DesktopUi.Commands;
using Cryptocurrencies.DesktopUi.Views;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly FrameContainer _frameContainer;
    private readonly CurrencyPage _currencyPage;
    private readonly CoinsPage _coinsPage;
    private readonly ConvertPage _convertPage;

    public MainWindowViewModel(FrameContainer frameContainerContainer, CurrencyPage currencyPage, CoinsPage coinsPage, ConvertPage convertPage)
    {
        _frameContainer = frameContainerContainer;
        _currencyPage = currencyPage;
        _coinsPage = coinsPage;
        _convertPage = convertPage;
    }

    public ICommand GoToCurrencyCommand => new CommandHandler(() =>
    {
        _frameContainer.NavigationFrame.NavigationService.Navigate(_currencyPage);
    }, () => true);
    
    public ICommand GoToCoinsCommand => new CommandHandler(() =>
    {
        _frameContainer.NavigationFrame.NavigationService.Navigate(_coinsPage);
    }, () => true);
    
    public ICommand GoToConvertCommand => new CommandHandler(() =>
    {
        _frameContainer.NavigationFrame.NavigationService.Navigate(_convertPage);
    }, () => true);
}