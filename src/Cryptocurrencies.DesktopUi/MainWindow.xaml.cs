using System.Windows;
using Cryptocurrencies.DesktopUi.Views;

namespace Cryptocurrencies.DesktopUi;

public partial class MainWindow : Window
{
    private readonly CoinsPage _coinsPage;
    private readonly CurrencyPage _currencyPage;
    private readonly ConvertPage _convertPage;
    public MainWindow(CoinsPage coinsPage, CurrencyPage currencyPage, ConvertPage convertPage)
    {
        _coinsPage = coinsPage;
        _currencyPage = currencyPage;
        _convertPage = convertPage;

        InitializeComponent();

        Frame.NavigationService.Navigate(coinsPage);
    }

    private void CurrencyPageButton_OnClick(object sender, RoutedEventArgs e)
    {
        Frame.NavigationService.Navigate(_currencyPage);
    }

    private void HomePageButton_OnClick(object sender, RoutedEventArgs e)
    {
        Frame.NavigationService.Navigate(_coinsPage);
    }

    private void ConvertButton_OnClick(object sender, RoutedEventArgs e)
    {
        Frame.NavigationService.Navigate(_convertPage);
    }
}