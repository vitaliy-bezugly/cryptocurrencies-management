using System.Windows.Input;
using Cryptocurrencies.DesktopUi.Commands;
using Cryptocurrencies.DesktopUi.Views;

namespace Cryptocurrencies.DesktopUi.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly FrameContainer _frameContainer;
    private readonly CurrencyPage _currencyPage;

    public MainWindowViewModel(FrameContainer frameContainerContainer, CurrencyPage currencyPage)
    {
        _frameContainer = frameContainerContainer;
        _currencyPage = currencyPage;
    }

    public ICommand GoToCurrencyCommand => new CommandHandler(() =>
    {
        _frameContainer.NavigationFrame.NavigationService.Navigate(_currencyPage);
    }, () => true);
}